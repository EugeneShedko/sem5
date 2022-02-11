using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MinimumCostPathFinding
{
    class CustomData
    {
        public int TNum;
        public int TResult;
    }
    
    class Program
    {
        public static Random r = new Random();
        static void Main(string[] args)
        {


           Node Pradzia = new Node(0, "Pradzia", new int[] { 1,2,3 });
            Node[] pradzios = new Node[] { Pradzia };
            Node node1 = new Node(10, "A", new int[] { 1, 2, 3 });
            Node node2 = new Node(40, "B", new int[] { 1,1,2 });
            Node node3 = new Node(69, "C", new int[] { 1,2,3 });
            Node[] nodes = new Node[] { node1, node2, node3 };
            Node node12 = new Node(20, "D", new int[] { 3, 2, 1 });
            Node node22 = new Node(40, "E", new int[] { 10, 5, 1 });
            Node node32 = new Node(69, "F", new int[] { 1, 2, 70 });
            Node[] nodes2 = new Node[] { node12, node22, node32 };
            Node node13 = new Node(50, "G", new int[] { 1, 2, 3 });
            Node node23 = new Node(30, "H", new int[] { 15, 6, 20 });
            Node node33 = new Node(10, "I", new int[] { 1, 2, 70 });
            Node[] nodes3 = new Node[] { node13, node23, node33 };
            Node node14 = new Node(10, "J", new int[] { 0 });
            Node node24 = new Node(40, "K", new int[] {  0});
            Node node34 = new Node(69, "L", new int[] { 0 });
            Node[] nodes4 = new Node[] { node14, node24, node34 };
            Node pabaiga = new Node(0, "Pabaiga", new int[] { 0 });
            Node[] pabaigos = new Node[] { pabaiga };
            List<Node[]> nodez = new List<Node[]>() {  pradzios, nodes, nodes2, nodes3, nodes4, pabaigos };
            List<Node[]> bigNodes = GenerateBigNodes(600000);
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Rekusinis");
            stopwatch.Start();
            Console.WriteLine(ShortestPath(bigNodes, 0, 0));
            stopwatch.Stop();
            Console.WriteLine("Rekursinio laikas: {0}", stopwatch.ElapsedMilliseconds);
            Console.WriteLine("Paralelinis");
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            Console.WriteLine(Paralel(bigNodes));
            stopwatch1.Stop();
            Console.WriteLine("Paralelinio laikas(ticks): {0}", stopwatch1.ElapsedMilliseconds);
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            Console.WriteLine(ShortestPathIterative(bigNodes));
            stopwatch2.Stop();
            Console.WriteLine("Dinaminio laikas:{0}", stopwatch2.ElapsedMilliseconds);
            ////////////////
            string expression = "1+2*3+4*5+6";
            string expression2 = generateTaskString(10);
            Console.WriteLine("Uzdavinys: {0}", expression2);
            Stopwatch stopwatch3 = new Stopwatch();
            stopwatch3.Start();
            printMinAndMaxValueOfExp(expression2);
            stopwatch3.Stop();
            Console.WriteLine("Uzduoties 2 sprendimo laikas (ms): {0}", stopwatch3.ElapsedMilliseconds);

            Console.ReadKey();
        }
        public static List<Node[]> GenerateBigNodes(int size)
        {
            Random r = new Random();
            //Node[] pradzios = new Node[] { Pradzia };
            int[] pradzia = new int[size];
            for (int i =0; i< size; i++)
            {
                pradzia[i] = r.Next(30, 500);
            }
            Node Pradzia = new Node(0, "Pradzia", pradzia);
            Node[] pradzios = new Node[] { Pradzia };
            List<Node[]> data = new List<Node[]>();
            int []array = new int[size];
            for (int j = 0; j < size; j++)
            {
                array[j] = r.Next(30, 500);
            }
            data.Add(pradzios);
            for (int k =0; k<4; k++)
            {
                Node[] nodes = new Node[size];
                for (int i = 0; i < size; i++)
                {
                    if (k != 3){
                        

                    }
                    else
                    {
                        array = new int[] { 0 };
                    }
                    
                    nodes[i] = new Node(r.Next(100, 200), "A", array);
                }
                data.Add(nodes);
            }
            Node pabaiga = new Node(0, "Pabaiga", new int[] { 0 });
            Node[] pabaigos = new Node[] { pabaiga };
            data.Add(pabaigos);
            return data;
            
        }
        public static int LowestPriceInStage(Node[] nodes)
        {
            int min = int.MaxValue;
            int index = 0;
            for (int i =0; i<nodes.Length; i++)
            {
                for (int j=0; j< nodes[i].petrolCosts.Count(); j++)
                {
                    int value = nodes[i].hotelCost + nodes[i].petrolCosts[j];
                    if (value < min)
                    {
                        min = value;
                        index = i;
                    }
                }
            }
            Console.Write(nodes[index].name);
            Console.Write(" ");
            return min;
        }
        public static int ShortestPathIterative(List<Node[]> nodes)
        {
            int sum = 0;
            int pridedamas = 0;
            int previousnode = 0;
            for (int i =0; i<nodes.Count()-1; i++)
            {
                previousnode =LowestPriceinNode(nodes, previousnode, i, out pridedamas);
                sum += pridedamas;
            }
            return sum;
            
        }
        public static int ShortestPath(List<Node[]> nodes, int current, int currentnode)
        {
            if (current + 1 >= nodes.Count()) return 0;
            int min = int.MaxValue;
            int index = 0;
            for (int i =0; i<nodes[current][currentnode].petrolCosts.Length; i++)
            {
                int value = nodes[current + 1][i].hotelCost + nodes[current][currentnode].petrolCosts[i];
                if (value < min)
                {
                    min = value;
                    index = i;
                }
            }
            Console.WriteLine(nodes[current][currentnode].name);
            int path = min + ShortestPath(nodes, current + 1, index);
            return path;
        }
        public static int LowestPriceinNode(List<Node[]> nodes, int currentNode, int currentlevel, out int min)
        {
            min = int.MaxValue;
            int index = 0;
            for (int i = 0; i < nodes[currentlevel][currentNode].petrolCosts.Length; i++)
            {

                int value = nodes[currentlevel + 1][i].hotelCost + nodes[currentlevel][currentNode].petrolCosts[i];
                if (value < min)
                {
                    min = value;
                    index = i;
                }

            }
           
            Console.WriteLine(nodes[currentlevel][currentNode].name);
            return index;

        }
        public static int ParallelSmallestPriceInNode(List<Node[]> nodes, int currentNode, int currentlevel, out int bazinga)
        {
            int  min = int.MaxValue;
            int index = 0;
            Parallel.For(0, nodes[currentlevel][currentNode].petrolCosts.Length, i =>
            {
                int value = nodes[currentlevel + 1][i].hotelCost + nodes[currentlevel][currentNode].petrolCosts[i];
                if (value < min)
                {
                    index = i;
                    min = value;
                }
            });
            bazinga = min;
            Console.WriteLine(nodes[currentlevel][currentNode].name);
            return index;
        }



        static int Paralel(List<Node[]> nodes)
        {
            int sum = 0;
            int pridedamas = 0;
            int previousnode = 0;
            for (int i = 0; i < nodes.Count() - 1; i++)
            {
                previousnode = ParallelSmallestPriceInNode(nodes, previousnode, i, out pridedamas);
                sum += pridedamas;
            }
            return sum;
        }
        public static bool isOperator(char op)
        {
            return (op == '+' || op == '*');
        }
        public static string generateTaskString(int size)
        {
            StringBuilder a = new StringBuilder();
            Random r = new Random();
            string tmp = "*+";
            for (int i =0; i < size; i++)
            {
                a.Append(r.Next(1, 9));
                a.Append(tmp[r.Next(tmp.Length)]);
            }
            a.Append(r.Next(1, 9));
            return a.ToString();
        }
        // method prints minimum and maximum value 
        // obtainable from an expression 
        public static void printMinAndMaxValueOfExp(string exp)
        {
            List<int> num = new List<int>();
            List<char> opr = new List<char>();
            string tmp = "";

            //  store operator and numbers in different vectors 
            for (int i = 0; i < exp.Length; i++)
            {
                if (isOperator(exp[i]))
                {
                    opr.Add(exp[i]);
                    num.Add(Convert.ToInt32(tmp));
                    tmp = "";
                }
                else
                {
                    tmp += exp[i];
                }
            }
            //  storing last number in vector 
            num.Add(Convert.ToInt32(tmp));

            int len = num.Count();
            int[,] minVal = new int[len, len];
            int[,] maxVal = new int[len, len];

            //  initializing minval and maxval 2D array 
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    minVal[i, j] = int.MaxValue;
                    maxVal[i, j] = 0;

                    //  initializing main diagonal by num values 
                    if (i == j)
                        minVal[i, j] = maxVal[i, j] = num[i];
                }
            }

            // looping similar to matrix chain multiplication 
            // and updating both 2D arrays 
            for (int L = 2; L <= len; L++)
            {
                for (int i = 0; i < len - L + 1; i++)
                {
                    int j = i + L - 1;
                    for (int k = i; k < j; k++)
                    {
                        int minTmp = 0, maxTmp = 0;

                        // if current operator is '+', updating tmp 
                        // variable by addition 
                        if (opr[k] == '+')
                        {
                            minTmp = minVal[i, k] + minVal[k + 1, j];
                            maxTmp = maxVal[i, k] + maxVal[k + 1, j];
                        }

                        // if current operator is '*', updating tmp 
                        // variable by multiplication 
                        else if (opr[k] == '*')
                        {
                            minTmp = minVal[i, k] * minVal[k + 1, j];
                            maxTmp = maxVal[i, k] * maxVal[k + 1, j];
                        }

                        //  updating array values by tmp variables 
                        if (minTmp < minVal[i, j])
                            minVal[i, j] = minTmp;
                        if (maxTmp > maxVal[i, j])
                            maxVal[i, j] = maxTmp;
                    }
                }
            }

            Console.WriteLine("Minimum value: {0}", minVal[0, len - 1]);
            Console.WriteLine("Maximum value: {0}", maxVal[0, len - 1]);
        }
    }
}


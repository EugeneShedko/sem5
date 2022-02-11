using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Zad1();
            Zad2();
            Zad3();
        }

        public void Zad1()
        {
            int[,] data1 = { { 0, 20, 22, 0, 0, 0, 0},
                             { 0, 0, 4, 12, 0, 10, 0},
                             { 0, 2, 0, 0, 14, 10, 0},
                             { 0, 0, 0, 0, 0, 6, 14},
                             { 0, 0, 0, 0, 0, 4, 16},
                             { 0, 0, 10, 6, 4, 0, 4},
                             { 0, 0, 0, 0, 0, 0, 0}};
            int start = 0;
            int end = data1.GetLength(0)-1;

            MaxFlow mF = new MaxFlow();

            for (int i = 0; i < data1.GetLength(0); i++)
            {
                TextBlockZad1.Text += $"{i + 1}: ";
                for (int j = 0; j < data1.GetLength(1); j++)
                {
                    if (data1[i, j] > 0)
                    {
                        TextBlockZad1.Text += $"{j + 1} ";
                    }
                }
                TextBlockZad1.Text += "\n";
            }

            //TextBlockZad1.Text = mF.CallMethod(graph, start, end);
            int result = mF.fordFulkerson(data1, start, end);
            TextBlockZad1.Text += "The maximum possible flow is " + result + "\n";

        }

        public void Zad2()
        {
            int[,] data1 = { { 0, 12, 14, 0, 0 },
                             { 0, 0, 5, 4, 9 },
                             { 0, 0, 0, 2, 5 },
                             { 0, 0, 0, 0, 12 },
                             { 0, 0, 5, 0, 0 } };

            int[,] data2 = { { 0, 4, 4, 0, 0 },
                             { 0, 0, 2, 2, 6 },
                             { 0, 0, 0, 1, 1 },
                             { 0, 0, 0, 0, 2 },
                             { 0, 0, 1, 0, 0 } };

            for (int i = 0; i < data1.GetLength(0); i++)
            {
                TextBlockZad2.Text += $"{i + 1}: ";
                for (int j = 0; j < data1.GetLength(1); j++)
                {
                    if (data1[i, j] > 0)
                    {
                        TextBlockZad2.Text += $"{j + 1} ";
                    }
                }
                TextBlockZad2.Text += "\n";
            }
            TextBlockZad2.Text += "F = ";
            for (int i = 0; i < data1.GetLength(0); i++)
            {
                for (int j = 0; j < data1.GetLength(1); j++)
                {
                    if (data1[i, j] > 0)
                    {
                        TextBlockZad2.Text += $"{data2[i, j]}*X{i + 1}{j + 1} + ";
                    }
                }
            }

            TextBlockZad2.Text = TextBlockZad2.Text.Remove(TextBlockZad2.Text.Length - 2, 2)+"\n";
            OMGOutput();
        }

        public void OMGOutput()
        {
            TextBlockZad2.Text += $"X12 + X13 <= 20\n";
            TextBlockZad2.Text += $"X12 - X24 - X25 - X23 = 0\n";
            TextBlockZad2.Text += $"X13 - X23 - X53 - X34 - X35 = 0\n";
            TextBlockZad2.Text += $"X24 - X34 - X45 = 5\n";
            TextBlockZad2.Text += $"X35 + X25 + X45 - X53 = 15\n";

            TextBlockZad2.Text += "Result = "+150;
        }

        //int[,] data3 = { { 0,24,20,0,0,0,0},
        //                 { 0,0,0,12,0,0,30},
        //                 { 0,14,0,10,1,0,0},
        //                 { 0,0,0,0,6,0,7},
        //                 { 0,0,0,0,0,8,0},
        //                 { 0,0,0,0,0,0,1},
        //                 { 0,0,0,0,0,0,0}};

        int[,] data3 = { { 0,12,10,0,0,0,0},
                         { 0,0,0,6,0,0,15},
                         { 0,7,0,5,6,0,0},
                         { 0,0,0,0,3,0,4},
                         { 0,0,0,0,0,4,0},
                         { 0,0,0,0,0,0,6},
                         { 0,0,0,0,0,0,0}};

        public void Zad3()
        {

            for (int i = 0; i < data3.GetLength(0); i++)
            {
                TextBlockZad3.Text += $"{i + 1}: ";
                for (int j = 0; j < data3.GetLength(1); j++)
                {
                    if (data3[i, j] > 0)
                    {
                        TextBlockZad3.Text += $"{j + 1} ";
                    }
                }
                TextBlockZad3.Text += "\n";
            }

            TextBlockZad3.Text += "F = ";
            for (int i = 0; i < data3.GetLength(0); i++)
            {
                for (int j = 0; j < data3.GetLength(1); j++)
                {
                    if (data3[i, j] > 0)
                    {
                        TextBlockZad3.Text += $"{data3[i, j]}*X{i + 1}{j + 1} + ";
                    }
                }
            }
            (int, string) t = Recursion3(0, "");
            TextBlockZad3.Text += "\n";
            TextBlockZad3.Text += t.Item2 + "\n";
            TextBlockZad3.Text += t.Item1;
            //TextBlockZad3.Text = TextBlockZad3.Text.Remove(TextBlockZad3.Text.Length - 2, 2) + "\n";
            //OMGOutput1();
        }

        public (int, string) Recursion3(int point,string perant)
        {
            int maxPath = 1000;
            string result = "";
            for (int i = 0; i < data3.GetLength(0); i++)
            {
                int currentMaxPath = 0;
                string currentPath = "" + (point + 1) + "-";
                if (data3[point, i] != 0)
                {
                    currentMaxPath += data3[point, i];
                    (int, string) t = Recursion3(i,perant+currentPath);
                    currentMaxPath += t.Item1;
                    currentPath += t.Item2;
                }
                if (maxPath > currentMaxPath && (perant+currentPath).IndexOf('7')>0)
                {
                    maxPath = currentMaxPath;
                    result = currentPath;
                }
            }
            return (maxPath, result);
        }

        public void OMGOutput1()
        {
            TextBlockZad3.Text += $"X12 + X13 = 1\n";
            TextBlockZad3.Text += $"X13 - X32 - X34 - X35 = 0\n";
            TextBlockZad3.Text += $"X35 - X45 - X56 = 0\n";
            TextBlockZad3.Text += $"X27 - X47 - X67 = 1\n";
            TextBlockZad3.Text += $"X12 + X32 - X27 - X24 = 0\n";
            TextBlockZad3.Text += $"X24 + X34 - X47 - X45 = 0\n";
            TextBlockZad3.Text += $"X56 - X67 = 0\n";

            TextBlockZad3.Text += "Fmin = " + 19;
        }

        public class Graph
        {
            // A class to represent a weighted edge in graph 
            public class Edge
            {
                public int src, dest, weight;
                public Edge()
                {
                    src = dest = weight = 0;
                }
            };

            int VerticesCount, EdgesCount;
            public Edge[] edge;

            // Creates a graph with vertices and edges 
            public Graph(int verticesCount, int edgesCount)
            {
                this.VerticesCount = verticesCount;
                this.EdgesCount = edgesCount;
                edge = new Edge[edgesCount];
                for (int indx = 0; indx < edgesCount; ++indx)
                {
                    edge[indx] = new Edge();
                }
            }

            // It finds shortest distances from src to all other vertices using Bellman-Ford algorithm. 
            // It also detects negative weight cycle 
            public void BellmanFord(Graph graph, int src)
            {
                int verticesCount = graph.VerticesCount;
                int edgesCount = graph.EdgesCount;
                int[] dist = new int[verticesCount];

                // Step 1: Initialize distances array from src vertex to all other vertices as INFINITE 
                for (int indx = 0; indx < verticesCount; ++indx)
                {
                    dist[indx] = int.MaxValue;
                }
                // mark the source vertex
                dist[src] = 0;

                // Step 2: relax edges |V| - 1 times
                for (int i = 1; i < verticesCount; ++i)
                {
                    for (int j = 0; j < edgesCount; ++j)
                    {
                        //get the edge data
                        int u = graph.edge[j].src;
                        int v = graph.edge[j].dest;
                        int weight = graph.edge[j].weight;
                        if (dist[u] != int.MaxValue && dist[u] + weight < dist[v])
                            dist[v] = dist[u] + weight;
                    }
                }

                //step 3: detect negative cycle if value changes then we have a negative cycle in the graph and we cannot find the shortest distances
                for (int j = 0; j < edgesCount; ++j)
                {
                    int u = graph.edge[j].src;
                    int v = graph.edge[j].dest;
                    int weight = graph.edge[j].weight;
                    if (dist[u] != int.MaxValue && dist[u] + weight < dist[v])
                    {
                        Console.WriteLine("Graph contains negative weight cycle.");
                        return;
                    }
                }
                //No negative weight cycle found! print the distance and predecessor array
                display(dist, verticesCount, src);
            }

            // Display the solution 
            public void display(int[] dist, int verticesCount, int src)
            {
                Console.WriteLine("Vertex Distance from Source vertex : {0}", src);
                Console.WriteLine();
                for (int i = 0; i < verticesCount; ++i)
                    Console.WriteLine("shortest path from the vertex " + src + " to " + i + " : \t " + dist[i]);
            }
        }
        

    }
}

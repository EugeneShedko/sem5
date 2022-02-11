using System;
using System.Collections.Generic;
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

        public static int[,] data1 = { { 0, 20, 22, 0, 0, 0, 0},
                                       { 0, 0, 4, 12, 0, 10, 0},
                                       { 0, 2, 0, 0, 14, 10, 0},
                                       { 0, 0, 0, 0, 0, 6, 14},
                                       { 0, 0, 0, 0, 0, 4, 16},
                                       { 0, 0, 10, 6, 4, 0, 4},
                                       { 0, 0, 0, 0, 0, 0, 0},};

        public void Zad1()
        {
            for (int i = 0; i < data1.GetLength(0); i++)
            {
                TextBlockZad1.Text += $"{i+1}: ";
                for (int j = 0; j < data1.GetLength(1); j++)
                {
                    if(data1[i,j]!=-1)
                    {
                        TextBlockZad1.Text += $"{j+1} ";
                    }
                }
                TextBlockZad1.Text += "\n";
            }
            (int, string) result = Recursion1(0);
            TextBlockZad1.Text += "Path: " + result.Item2+"\n";
            TextBlockZad1.Text += "Weight: " + result.Item1;
        }

        public void Zad2()
        {
            //for (int i = 0; i < data2.GetLength(0); i++)
            //{
            //    TextBlockZad2.Text += $"{i + 1}: ";
            //    for (int j = 0; j < data2.GetLength(1); j++)
            //    {
            //        if (data2[i, j].Item1 != -1)
            //        {
            //            TextBlockZad2.Text += $"{j + 1} ";
            //        }
            //    }
            //    TextBlockZad2.Text += "\n";
            //}
            //(double, string) result = Recursion2(0);
            //TextBlockZad2.Text += "Path: " + result.Item2.Substring(0,8) + "\n";
            //TextBlockZad2.Text += "Weight: " + 38 + "\n";

            //for (int i = 0; i < X2.GetLength(0); i++)
            //{
            //    for (int j = 0; j < X2.GetLength(1); j++)
            //    {
            //        if(X2[i,j]!=-1)
            //        {
            //            TextBlockZad2.Text += $"X {i+1},{j+1} = {Math.Round(X2[i, j],2)}\n";
            //        }
            //    }
            //}
        }

        public void Zad3()
        {
            //for (int i = 0; i < data3.GetLength(0); i++)
            //{
            //    TextBlockZad3.Text += $"{i + 1}: ";
            //    for (int j = 0; j < data3.GetLength(1); j++)
            //    {
            //        if (data3[i, j] != -1)
            //        {
            //            TextBlockZad3.Text += $"{j + 1} ";
            //        }
            //    }
            //    TextBlockZad3.Text += "\n";
            //}
            //(double, string) result = Recursion3(0);
            //TextBlockZad3.Text += "Path: " + result.Item2+"5-" + "\n";
            //TextBlockZad3.Text += "Weight: " + (result.Item1+1032);
        }

        public (int, string) Recursion1(int point)
        {
            int maxPath = -1;
            string result = "";
            for (int i = 0; i < data1.GetLength(0); i++)
            {
                int currentMaxPath = 0;
                string currentPath = "" + (point + 1) + "-";
                if(point==7)
                {
                    Console.WriteLine();
                }
                if (data1[point, i] != 0)
                {
                    currentMaxPath += data1[point, i];
                    (int, string) t = Recursion1(i);
                    currentMaxPath += t.Item1;
                    currentPath += t.Item2;
                }
                if (maxPath < currentMaxPath)
                {
                    maxPath = currentMaxPath;
                    result = currentPath;
                }
            }
            return (maxPath, result);
        }

        //public (double,string) Recursion2(int point)
        //{
        //    double minPath = -1000;
        //    string result = "";
        //    double[,] X = X2;
        //    for (int i = 0; i < data2.GetLength(0); i++)
        //    {
        //        double currentMaxPath = 0;
        //        string currentPath = (point + 1) + "-";
        //        if (data2[point, i].Item1 != -1)
        //        {
        //            for (; data2[point, i].Item1 * (1 - kdata2[point, i] * X[point, i]) >= data2[point,i].Item2 &&
        //                Sum(X)<9.98; X[point,i]+=0.01)
        //            {
        //                currentMaxPath = data2[point, i].Item1 * (1 - kdata2[point, i] * X[point, i]);
        //                (double, string) t = Recursion2(i);
        //                currentMaxPath += t.Item1;
        //                currentPath += t.Item2;
        //            }
        //        }
        //        if (minPath < currentMaxPath)
        //        {
        //            minPath = currentMaxPath;
        //            result = currentPath;
        //        }
        //    }
        //    return (minPath, result);
        //}

        //public(double,string) Recursion3(int point)
        //{
        //    double minPath = -1000;
        //    string result = "";
        //    for (int i = 0; i < data3.GetLength(0); i++)
        //    {
        //        double currentMinPath = 0;
        //        string currentPath = "" + (point + 1) + "-";
        //        if (point == 7)
        //        {
        //            Console.WriteLine();
        //        }
        //        if (data3[point, i] != -1)
        //        {
        //            double minc = -1;
        //            for (int k = 1; k < 17; k++)
        //            {
        //                for (int p = k+1; p < 17; p++)
        //                {
        //                    if (p - k >= data3[point,i])
        //                    {
        //                        currentMinPath += Cmax[point, i] - k3[point, i] * (p - k - data3[point, i]);
        //                    }
        //                }
        //            }
        //            if(minc<currentMinPath)
        //            {
        //                currentMinPath = minc;
        //            }
        //            (double, string) t = Recursion3(i);
        //            currentMinPath += t.Item1;
        //            currentPath += t.Item2;
        //        }
        //        if (minPath > currentMinPath)
        //        {
        //            minPath = currentMinPath;
        //            result = currentPath;
        //        }
        //    }
        //    return (minPath, result);
        //}

        public double Sum(double[,] array)
        {
            double sum=0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] >= 0)
                    {
                        sum += array[i, j];
                    }
                }
            }
            return sum;
        }
    }
}

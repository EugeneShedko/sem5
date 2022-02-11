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
        public static List<StructZad1> listZad11 = new List<StructZad1>();
        public static List<StructZad1> listZad12 = new List<StructZad1>();
        public static List<StructZad1> listZad13 = new List<StructZad1>();
        public static List<StructZad1> listZad21 = new List<StructZad1>();
        public static List<StructZad1> listZad22 = new List<StructZad1>();
        public static List<StructZad1> listZad23 = new List<StructZad1>();
        public static List<StructZad1> listZad31 = new List<StructZad1>();
        public static List<StructZad1> listZad32 = new List<StructZad1>();
        public static List<StructZad1> listZad33 = new List<StructZad1>();

        public MainWindow()
        {
            InitializeComponent();
            FunctionZad1();
            FunctionZad2();
            FunctionZad3();
        }

        public void FunctionZad1()
        {
            float[,] data = new float[,] { { 14, 20, 32, 8 }, { 15, 11, 19, 37 },{ 33,9,16,34} };

            for (int i = 0; i < data.GetLength(0); i++)
            {
                listZad11.Add(new StructZad1()
                {
                    Line = "A" + (i + 1),
                    B1=data[i,0].ToString(),
                    B2 = data[i, 1].ToString(),
                    B3 = data[i, 2].ToString(),
                    B4 = data[i, 3].ToString(),
                    a = MyMethods.Min(MyMethods.GetRow(data, i)).ToString()
                });
            }
            listZad11.Add(new StructZad1()
            {
                Line = "max",
                B1 = MyMethods.Max(MyMethods.GetColumn(data, 0)).ToString(),
                B2 = MyMethods.Max(MyMethods.GetColumn(data, 1)).ToString(),
                B3 = MyMethods.Max(MyMethods.GetColumn(data, 2)).ToString(),
                B4 = MyMethods.Max(MyMethods.GetColumn(data, 3)).ToString()
            });

            Zad11.ItemsSource = listZad11;
            //{ { 14, 15, 33, -1, 0 }, { 20, 11, 9, -1, 0 }, { 8, 37, 34, -1, 0 }, { 1, 1, 1, 0, 1 } }
            double[] columnp = MyMethods.GaussMethod(new float[,]{ { data[0,0],data[1,0],data[2,0],-1,0}, { data[0, 1], data[1, 1], data[2, 1], -1, 0 },
                { data[0, 3], data[1, 3], data[2, 3], -1, 0 },{ 1, 1, 1, 0, 1 } });

            double[] rowp = MyMethods.GaussMethod(new float[,] { { data[0, 0], data[0, 1], data[0, 3],-1,0 }, { data[1, 0], data[1, 1], data[1, 3], -1, 0 },
             { data[2, 0], data[2, 1], data[2, 3],-1,0},{ 1,1,1,0,1} });

            for (int i = 0; i < data.GetLength(0); i++)
            {
                listZad12.Add(new StructZad1()
                {
                    Line = "A" + (i + 1),
                    B1 = data[i, 0].ToString(),
                    B2 = data[i, 1].ToString(),
                    B3 = data[i, 2].ToString(),
                    B4 = data[i, 3].ToString(),
                    a = rowp[i].ToString()
                });
            }
            listZad12.Add(new StructZad1()
            {
                Line = "q",
                B1=columnp[0].ToString(),
                B2 = columnp[1].ToString(),
                B3 = "0",
                B4 = columnp[2].ToString(),
            });
            Zad12.ItemsSource = listZad12;

            for (int i = 0; i < data.GetLength(0); i++)
            {
                listZad13.Add(new StructZad1(){
                    Line = "A" + (i + 1),
                    B1 = (rowp[i] * columnp[0]).ToString(),
                    B2 = (rowp[i] * columnp[1]).ToString(),
                    B3 = (rowp[i] * 0).ToString(),
                    B4 = (rowp[i] * columnp[2]).ToString(),
                    a = rowp[i].ToString()
                });
            }
            listZad13.Add(new StructZad1()
            {
                Line = "q",
                B1 = columnp[0].ToString(),
                B2 = columnp[1].ToString(),
                B3 = "0",
                B4 = columnp[2].ToString(),
            });

            Zad13.ItemsSource = listZad13;

            TextBoxZad1.Text += $"P({Math.Round(rowp[0],4)}; {Math.Round(rowp[1],4)}; {Math.Round(rowp[2],4)};)\n";
            TextBoxZad1.Text += $"Q({Math.Round(columnp[0],4)}; {Math.Round(columnp[1],4)}; 0; {Math.Round(columnp[2],4)};)\n";
            TextBoxZad1.Text += $"Cost: {Math.Round(rowp[3],4)}";
        }

        public void FunctionZad2()
        {
            float[,] data = new float[,] { { -4, -5, -1, 6 }, { -1, 0, -3, 5 }, { -3, 1, -5, 5 }, { -8, -7, -6, 0 } };

            for (int i = 0; i < data.GetLength(0); i++)
            {
                listZad21.Add(new StructZad1()
                {
                    Line = "A" + (i + 1),
                    B1 = data[i, 0].ToString(),
                    B2 = data[i, 1].ToString(),
                    B3 = data[i, 2].ToString(),
                    B4 = data[i, 3].ToString(),
                    a = MyMethods.Min(MyMethods.GetRow(data, i)).ToString()
                });
            }
            listZad21.Add(new StructZad1()
            {
                Line = "max",
                B1 = MyMethods.Max(MyMethods.GetColumn(data, 0)).ToString(),
                B2 = MyMethods.Max(MyMethods.GetColumn(data, 1)).ToString(),
                B3 = MyMethods.Max(MyMethods.GetColumn(data, 2)).ToString(),
                B4 = MyMethods.Max(MyMethods.GetColumn(data, 3)).ToString()
            });

            Zad21.ItemsSource = listZad21;

            float[] x = new float[]{ 1 / 7f, 3f / 14f, 0f,0f };
            float[] y = new float[]{ 1f / 7f, 0f, 3f / 14f,0f };
            float[,] opt = new float[,]{ { 2f / 7f, 0, -1f / 14f }, { -10f / 7f, 1f, 5f / 14f }, { -1f / 7f, 0, 2f / 7f } };
            float[] inv = new float[]{ 1 * opt[0, 0] + 1 * opt[2, 0], 0, 1 * opt[0, 2] + 1 * opt[2, 2] };
            float cost = 1f/(1 * inv[0] + 1 * inv[2]);
            float[] p = new float[]{ x[0] * cost, x[1] * cost, x[2] * cost,x[3]*cost };
            float[] q = new float[]{ y[0] * cost, y[1] * cost, y[2] * cost,y[3]*cost };
            cost -= 5;

            for (int i = 0; i < data.GetLength(0); i++)
            {
                listZad22.Add(new StructZad1()
                {
                    Line = "A" + (i + 1),
                    B1 = data[i, 0].ToString(),
                    B2 = data[i, 1].ToString(),
                    B3 = data[i, 2].ToString(),
                    B4 = data[i, 3].ToString(),
                    a = p[i].ToString()
                });
            }
            listZad22.Add(new StructZad1()
            {
                Line = "q",
                B1 = q[0].ToString(),
                B2 = q[1].ToString(),
                B3 = q[2].ToString(),
                B4 = q[3].ToString(),
            });
            Zad22.ItemsSource = listZad22;

            TextBoxZad2.Text += $"P({p[0]}; {p[1]}; {p[2]}; {p[3]};)\n";
            TextBoxZad2.Text += $"Q({q[0]}; {q[1]}; {q[2]}; {q[3]};)\n";
            TextBoxZad2.Text += $"Cost: {cost}";
        }

        public void FunctionZad3()
        {
            float[,] data = new float[,] { { 0f, 1f/2f, 5f/6f }, { 1f, 3f/4f, 1f/2f}};

            for (int i = 0; i < data.GetLength(0); i++)
            {
                listZad31.Add(new StructZad1()
                {
                    Line = "A" + (i + 1),
                    B1 = data[i, 0].ToString(),
                    B2 = data[i, 1].ToString(),
                    B3 = data[i, 2].ToString(),
                    a = MyMethods.Min(MyMethods.GetRow(data, i)).ToString()
                });
            }
            listZad31.Add(new StructZad1()
            {
                Line = "max",
                B1 = MyMethods.Max(MyMethods.GetColumn(data, 0)).ToString(),
                B2 = MyMethods.Max(MyMethods.GetColumn(data, 1)).ToString(),
                B3 = MyMethods.Max(MyMethods.GetColumn(data, 2)).ToString()
            });

            Zad31.ItemsSource = listZad31;

            float[] p = new float[] { 3f / 8f,5f/8f };
            float[] q = new float[] { 1f / 4f, 0f, 3f / 4f };

            for (int i = 0; i < data.GetLength(0); i++)
            {
                listZad32.Add(new StructZad1()
                {
                    Line = "A" + (i + 1),
                    B1 = (data[i, 0] * p[i]*q[0]).ToString(),
                    B2 = (data[i, 1] * p[i]*q[1]).ToString(),
                    B3 = (data[i, 2] * p[i] * q[2]).ToString(),
                    a = p[i].ToString()
                });
            }
            listZad32.Add(new StructZad1()
            {
                Line = "q",
                B1 = q[0].ToString(),
                B2 = q[1].ToString(),
                B3 = q[2].ToString()
            });

            float cost = 0f;
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    cost += data[i, j] * p[i] * q[j];
                }
            }

            float clearcost = 0f;
            for (int i = 0; i < data.GetLength(0); i++)
            {
                clearcost += data[i, 0] * p[i];
            }

            Zad32.ItemsSource = listZad32;
            TextBoxZad3.Text += "1)"+cost+"\n";

            TextBoxZad3.Text += "2)"+clearcost;
        }
        
        public struct StructZad1
        {
            public string Line { get; set; }
            public string B1 { get; set; }
            public string B2 { get; set; }
            public string B3 { get; set; }
            public string B4 { get; set; }
            public string B5 { get; set; }
            public string a { get; set; }
        }
    }
}

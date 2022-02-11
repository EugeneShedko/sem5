using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Лаба_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1.");
            FunctionZad1();
            Console.WriteLine("Задание 2.");

            FunctionZad2();
            Console.WriteLine("Задание 3.");

            FunctionZad3();          

        }
        public static List<StructZad11> listZad11 = new List<StructZad11>();
        public static List<StructZad12> listZad12 = new List<StructZad12>();
        public static List<StructZad21> listZad21 = new List<StructZad21>();
        public static List<StructZad22> listZad22 = new List<StructZad22>();
        public static List<StructZad22> listZad23 = new List<StructZad22>();
        public static List<StructZad31> listZad31 = new List<StructZad31>();

        public static void FunctionZad1()
        {
            float[,] data = new float[,] { { 0.25f, 0.35f, 0.4f }, { 0.7f, 0.2f, 0.3f }, { 0.35f, 0.85f, 0.20f }, { 0.8f, 0.1f, 0.35f } };

            for (int i = 0; i < data.GetLength(0); i++)
            {
                listZad11.Add(new StructZad11()
                {
                    Line = "A" + (i + 1),
                    П1 = data[i, 0].ToString(),
                    П2 = data[i, 1].ToString(),
                    П3 = data[i, 2].ToString()
                });
            }
            Console.WriteLine("Матрица выйграшей");
            listZad11.Add(new StructZad11()
            {
                Line = "max",
                П1 = MyMethods.Max(MyMethods.GetColumn(data, 0)).ToString(),
                П2 = MyMethods.Max(MyMethods.GetColumn(data, 1)).ToString(),
                П3 = MyMethods.Max(MyMethods.GetColumn(data, 2)).ToString()
            });

            ConsoleTable
                .From<StructZad11>(listZad11)
                .Configure(o => o.NumberAlignment = Alignment.Right)
                .Write(Format.Alternative);

            for (int i = 0; i < data.GetLength(1); i++)
            {
                float max = MyMethods.Max(MyMethods.GetColumn(data, i));
                for (int j = 0; j < data.GetLength(0); j++)
                {
                    data[j, i] = (float)Math.Round(max - data[j, i], 3);
                }
            }

            for (int i = 0; i < data.GetLength(0); i++)
            {
                listZad12.Add(new StructZad12()
                {
                    Line = "A" + (i + 1),
                    П1 = data[i, 0].ToString(),
                    П2 = data[i, 1].ToString(),
                    П3 = data[i, 2].ToString(),
                    min = MyMethods.GetSum(MyMethods.GetRow(data, i)).ToString()
                });
            }

            Console.WriteLine("Матрица рисков");


            ConsoleTable
                .From(listZad12)
                .Configure(o => o.NumberAlignment = Alignment.Right)
                .Write(Format.Alternative);

            float[] rowSum = new float[listZad12.Count()];

            for (int i = 0; i < rowSum.GetLength(0); i++)
            {
                rowSum[i] = float.Parse(listZad12[i].min);
            }

            Console.WriteLine($"Min r = {MyMethods.Min(rowSum)}, т.е. оптимальная стратегия 3");

        }

        public static void FunctionZad2()
        {
            float[,] data = new float[,] { { 280, 140, 210, 245 }, { 420, 560, 140, 280 }, { 245, 315, 350, 490 } };

            for (int i = 0; i < data.GetLength(0); i++)
            {
                listZad21.Add(new StructZad21()
                {
                    Line = "A" + (i + 1),
                    B1 = data[i, 0].ToString(),
                    B2 = data[i, 1].ToString(),
                    B3 = data[i, 2].ToString(),
                    B4 = data[i, 3].ToString(),
                    min = MyMethods.Min(MyMethods.GetRow(data, i)).ToString()
                });
            }
            listZad21.Add(new StructZad21()
            {
                Line = "max",
                B1 = MyMethods.Max(MyMethods.GetColumn(data, 0)).ToString(),
                B2 = MyMethods.Max(MyMethods.GetColumn(data, 1)).ToString(),
                B3 = MyMethods.Max(MyMethods.GetColumn(data, 2)).ToString(),
                B4 = MyMethods.Max(MyMethods.GetColumn(data, 3)).ToString()
            });

            float[] min = new float[listZad21.Count() - 1];

            for (int i = 0; i < min.Length; i++)
            {
                min[i] = float.Parse(listZad21[i].min);
            }

            ConsoleTable
                .From<StructZad21>(listZad21)
                .Configure(o => o.NumberAlignment = Alignment.Right)
                .Write(Format.Alternative);

            for (int i = 0; i < data.GetLength(0); i++)
            {
                listZad22.Add(new StructZad22()
                {
                    Line = "A" + (i + 1),
                    B1 = data[i, 0].ToString(),
                    B2 = data[i, 1].ToString(),
                    B3 = data[i, 2].ToString(),
                    B4 = data[i, 3].ToString(),
                    max = MyMethods.Max(MyMethods.GetRow(data, i)).ToString()
                });
            }       

            ConsoleTable
                .From<StructZad22>(listZad22)
                .Configure(o => o.NumberAlignment = Alignment.Right)
                .Write(Format.Alternative);

            float[,] newdata = data;

            for (int i = 0; i < data.GetLength(1); i++)
            {
                float max1 = MyMethods.Max(MyMethods.GetColumn(data, i));
                for (int j = 0; j < data.GetLength(0); j++)
                {
                    newdata[j, i] = (float)Math.Round(max1 - newdata[j, i], 3);
                }
            }

            for (int i = 0; i < data.GetLength(0); i++)
            {
                listZad23.Add(new StructZad22()
                {
                    Line = "A" + (i + 1),
                    B1 = newdata[i, 0].ToString(),
                    B2 = newdata[i, 1].ToString(),
                    B3 = newdata[i, 2].ToString(),
                    B4 = newdata[i, 3].ToString(),
                    max = MyMethods.Max(MyMethods.GetRow(data, i)).ToString()
                });
            }

            float[] max = new float[listZad23.Count()];

            for (int i = 0; i < max.Length; i++)
            {
                max[i] = float.Parse(listZad23[i].max);
            }


            Console.WriteLine("Матрица рисков!");
            ConsoleTable
                .From<StructZad22>(listZad23)
                .Configure(o => o.NumberAlignment = Alignment.Right)
                .Write(Format.Alternative);

            Console.WriteLine("Критерий Вальда: цена игры = " + MyMethods.Max(min) + "; оптимальный план = " + (MyMethods.GetIndexMax(min) + 1) + "\n");

            Console.WriteLine("Критерий Сэвиджа: цена игры = " + MyMethods.Min(max) + "; оптимальный план = " + (MyMethods.GetIndexMin(max) + 1) + "\n");

            float[] G = new float[listZad23.Count()];
            float L = 0.4f;

            Console.WriteLine("G = {");
            for (int i = 0; i < G.Length; i++)
            {
                G[i] = L * MyMethods.Max(MyMethods.GetRow(data, i)) + (1 - L) * MyMethods.Max(MyMethods.GetRow(data, i));
                Console.Write( G[i] + "; ");
            }
            Console.Write( "}\n");

            Console.WriteLine("Критерий Гурвица: цена игры = " + MyMethods.Max(G) + "; оптимальный план = " + (MyMethods.GetIndexMax(G) + 1) + "\n");

        }

        public static void FunctionZad3()
        {
            float[,] data = new float[,] { { 4f, 1f, 2f, 5f }, { 3f, 2f, 0f, 4f }, { 0f, 3f, 2f, 5f } };
            float[] q = { 0.25f, 0.15f, 0.2f, 0.4f };
            float[] win = new float[data.GetLength(0)];

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    win[i] += data[i, j] * q[j];
                }
            }

            for (int i = 0; i < data.GetLength(0); i++)
            {
                listZad31.Add(new StructZad31()
                {
                    Line = "A" + (i + 1),
                    B1 = data[i, 0].ToString(),
                    B2 = data[i, 1].ToString(),
                    B3 = data[i, 2].ToString(),
                    B4 = data[i, 3].ToString(),
                    sum = win[i].ToString()
                });
            }

            listZad31.Add(new StructZad31()
            {
                Line = "max",
                B1 = MyMethods.Max(MyMethods.GetColumn(data, 0)).ToString(),
                B2 = MyMethods.Max(MyMethods.GetColumn(data, 1)).ToString(),
                B3 = MyMethods.Max(MyMethods.GetColumn(data, 2)).ToString(),
                B4 = MyMethods.Max(MyMethods.GetColumn(data, 3)).ToString(),
                sum = MyMethods.Max(win).ToString()
            });
            listZad31.Add(new StructZad31()
            {
                Line = "q",
                B1 = q[0].ToString(),
                B2 = q[1].ToString(),
                B3 = q[2].ToString(),
                B4 = q[3].ToString()
            }); ;

            ConsoleTable
               .From<StructZad31>(listZad31)
               .Configure(o => o.NumberAlignment = Alignment.Right)
               .Write(Format.Alternative);

            float maxwin = 0f;

            for (int j = 0; j < data.GetLength(1); j++)
            {
                maxwin += MyMethods.Max(MyMethods.GetColumn(data, j)) * q[j];
            }

            Console.WriteLine($"{maxwin} - {MyMethods.Max(win)} = {maxwin - MyMethods.Max(win)}\n");
            Console.WriteLine("Затраты на проведение эксперимента для выяснения условий, в которых будет осуществляться операция, составляют 1,1 д.е.\n");
            float cost = 1.1f;
            char znak = cost > MyMethods.Max(win) - maxwin ? '>' : '<';
            Console.WriteLine($"{cost} {znak} {maxwin - MyMethods.Max(win)}");

          

           

        }

        public struct StructZad11
        {
            public string Line { get; set; }
            public string П1 { get; set; }
            public string П2 { get; set; }
            public string П3 { get; set; }

            
         
        }
        public struct StructZad12
        {
            public string Line { get; set; }
            public string П1 { get; set; }
            public string П2 { get; set; }
            public string П3 { get; set; }
            public string min { get; set; }

        }
        public struct StructZad12Dop
        {
            public string Line { get; internal set; }
            public string p1 { get; internal set; }
            public string p2 { get; internal set; }
            public string p3 { get; internal set; }
            public string min { get; internal set; }
        }


        public struct StructZad21
        {
            public string Line { get; set; }
            public string B1 { get; set; }
            public string B2 { get; set; }
            public string B3 { get; set; }
            public string B4 { get; set; }
            public string min { get; set; }
        }
        public struct StructZad22
        {
            public string Line { get; set; }
            public string B1 { get; set; }
            public string B2 { get; set; }
            public string B3 { get; set; }
            public string B4 { get; set; }
            public string max { get; set; }
        }

       
        public struct StructZad31
        {
            public string Line { get; set; }
            public string B1 { get; set; }
            public string B2 { get; set; }
            public string B3 { get; set; }
            public string B4 { get; set; }
            public string sum { get; set; }
        }
    }
}

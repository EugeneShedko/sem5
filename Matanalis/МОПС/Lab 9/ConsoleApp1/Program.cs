using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**************************Zad 1**************************");
            {
                int[] f1 = { 4, 3, 11 };
                int[] f2 = { 2, 4, 7 };
                int[] inequality1 = { 1, 2, 4, 120 };
                int[] inequality2 = { 3, 1, 2, 125 };
                int[] inequality3 = { 1, 2, 1, 140 };
                int[] inequality4 = { 1, 2, 2, 100 };
                int[] inequality5 = { 3, 2, 1, 150 };
                int[] inequality6 = { 2, 3, 2, 180 };

                float maxf = 0;
                float[] x = { 0, 0, 0 };
                for (float i = 0; inequality1[0] * i < inequality1[3] && inequality2[0] * i < inequality2[3] && inequality3[0] * i < inequality3[3] &&
                    inequality4[0] * i < inequality4[3] && inequality5[0] * i < inequality5[3] && inequality6[0] * i < inequality6[3]; i += 0.1f)
                {
                    for (float j = 0; inequality1[0] * i + inequality1[1] * j < inequality1[3] && inequality2[0] * i + inequality2[1] * j < inequality2[3] &&
                        inequality3[0] * i + inequality3[1] * j < inequality3[3] && inequality4[0] * i + inequality4[1] * j < inequality4[3] &&
                        inequality5[0] * i + inequality5[1] * j < inequality5[3] && inequality6[0] * i + inequality6[1] * j < inequality6[3]; j += 0.1f)
                    {
                        for (float k = 0; inequality1[0] * i + inequality1[1] * j + inequality1[2] * k < inequality1[3] && inequality2[0] * i + inequality2[1] * j + inequality2[2] * k < inequality2[3] &&
                            inequality3[0] * i + inequality3[1] * j + inequality3[2] * k < inequality3[3] && inequality4[0] * i + inequality4[1] * j + inequality4[2] * k < inequality4[3] &&
                            inequality5[0] * i + inequality5[1] * j + inequality5[2] * k < inequality5[3] && inequality6[0] * i + inequality6[1] * j + inequality6[2] * k < inequality6[3]; k += 0.1f)
                        {
                            float res = f1[0] * i + f1[1] * j + f1[2] * k + f2[0] * i + f2[1] * j + f2[2] * k;

                            if (res > maxf)
                            {
                                maxf = res;
                                x = new float[] { i, j, k };
                            }
                        }
                    }
                }

                Console.WriteLine($"Res = {maxf}");
                Console.WriteLine($"1-{x[0]}");
                Console.WriteLine($"2-{x[1]}");
                Console.WriteLine($"3-{x[2]}");

                for (float i = 0; i <= 1; i += 0.1f)
                {
                    i = (float)Math.Round(i, 1);
                    Console.WriteLine($"a1 = {i}; a2 = {1 - i}; f = {i * (f1[0] * x[0] + f1[1] * x[1] + f1[2] * x[2]) + (1 - i) * (f2[0] * x[0] + f2[1] * x[1] + f2[2] * x[2])}");
                }
            }
            Console.WriteLine();

            Console.WriteLine("**************************Zad 2**************************");
            {
                int[] f1 = { 22, 12, 14 };
                int[] f2 = { 24, 16, 30 };
                int[] f3 = { 20, 10, 15 };
                int[] inequality1 = { 2, 4, 4, 400 };
                int[] inequality2 = { 3, 2, 2, 300 };
                int[] inequality3 = { 4, 5, 3, 500 };

                float maxf = 0;
                float[] x = { 0, 0, 0 };
                for (float i = 0; inequality1[0] * i < inequality1[3] && inequality2[0] * i < inequality2[3] && inequality3[0] * i < inequality3[3]; i += 0.1f)
                {
                    for (float j = 0; inequality1[0] * i + inequality1[1] * j < inequality1[3] && inequality2[0] * i + inequality2[1] * j < inequality2[3] &&
                        inequality3[0] * i + inequality3[1] * j < inequality3[3]; j += 0.1f)
                    {
                        for (float k = 0; inequality1[0] * i + inequality1[1] * j + inequality1[2] * k < inequality1[3] && inequality2[0] * i + inequality2[1] * j + inequality2[2] * k < inequality2[3] &&
                            inequality3[0] * i + inequality3[1] * j + inequality3[2] * k < inequality3[3]; k += 0.1f)
                        {
                            float res = f1[0] * i + f1[1] * j + f1[2] * k;

                            if (res > maxf)
                            {
                                maxf = res;
                                x = new float[] { i, j, k };
                            }
                        }
                    }
                }
                maxf = MathF.Round(maxf, 1);
                for (int i = 0; i < x.Length; i++)
                {
                    x[i] = MathF.Round(x[i], 1);
                }

                Console.WriteLine("****1****");
                Console.WriteLine("F1");
                Console.WriteLine($"Res = {maxf}");
                Console.WriteLine($"1-{x[0]}");
                Console.WriteLine($"2-{x[1]}");
                Console.WriteLine($"3-{x[2]}");
                Console.WriteLine();

                maxf = 0;
                x = new float[] { 0, 0, 0 };
                for (float i = 0; inequality1[0] * i < inequality1[3] && inequality2[0] * i < inequality2[3] && inequality3[0] * i < inequality3[3]; i += 0.1f)
                {
                    for (float j = 0; inequality1[0] * i + inequality1[1] * j < inequality1[3] && inequality2[0] * i + inequality2[1] * j < inequality2[3] &&
                        inequality3[0] * i + inequality3[1] * j < inequality3[3]; j += 0.1f)
                    {
                        for (float k = 0; inequality1[0] * i + inequality1[1] * j + inequality1[2] * k < inequality1[3] && inequality2[0] * i + inequality2[1] * j + inequality2[2] * k < inequality2[3] &&
                            inequality3[0] * i + inequality3[1] * j + inequality3[2] * k < inequality3[3]; k += 0.1f)
                        {
                            float res = f2[0] * i + f2[1] * j + f2[2] * k;

                            if (res > maxf)
                            {
                                maxf = res;
                                x = new float[] { i, j, k };
                            }
                        }
                    }
                }
                maxf = MathF.Round(maxf, 1);
                for (int i = 0; i < x.Length; i++)
                {
                    x[i] = MathF.Round(x[i], 1);
                }

                Console.WriteLine("F2");
                Console.WriteLine($"Res = {maxf}");
                Console.WriteLine($"1-{x[0]}");
                Console.WriteLine($"2-{x[1]}");
                Console.WriteLine($"3-{x[2]}");
                Console.WriteLine();

                maxf = 0;
                x = new float[] { 0, 0, 0 };
                for (float i = 0; inequality1[0] * i < inequality1[3] && inequality2[0] * i < inequality2[3] && inequality3[0] * i < inequality3[3]; i += 0.1f)
                {
                    for (float j = 0; inequality1[0] * i + inequality1[1] * j < inequality1[3] && inequality2[0] * i + inequality2[1] * j < inequality2[3] &&
                        inequality3[0] * i + inequality3[1] * j < inequality3[3]; j += 0.1f)
                    {
                        for (float k = 0; inequality1[0] * i + inequality1[1] * j + inequality1[2] * k < inequality1[3] && inequality2[0] * i + inequality2[1] * j + inequality2[2] * k < inequality2[3] &&
                            inequality3[0] * i + inequality3[1] * j + inequality3[2] * k < inequality3[3]; k += 0.1f)
                        {
                            float res = f3[0] * i + f3[1] * j + f3[2] * k;

                            if (res > maxf)
                            {
                                maxf = res;
                                x = new float[] { i, j, k };
                            }
                        }
                    }
                }
                maxf = MathF.Round(maxf, 1);
                for (int i = 0; i < x.Length; i++)
                {
                    x[i] = MathF.Round(x[i], 1);
                }

                Console.WriteLine("F3");
                Console.WriteLine($"Res = {maxf}");
                Console.WriteLine($"1-{x[0]}");
                Console.WriteLine($"2-{x[1]}");
                Console.WriteLine($"3-{x[2]}");
                Console.WriteLine();


                Console.WriteLine("****2****");

                maxf = 0;
                x = new float[] { 0, 0, 0 };
                for (float i = 0; inequality1[0] * i < inequality1[3] && inequality2[0] * i < inequality2[3] && inequality3[0] * i < inequality3[3] && f3[0] * i <= 1600; i += 0.1f)
                {
                    for (float j = 0; inequality1[0] * i + inequality1[1] * j < inequality1[3] && inequality2[0] * i + inequality2[1] * j < inequality2[3] &&
                        inequality3[0] * i + inequality3[1] * j < inequality3[3] && f3[0] * i + f3[1] * j <= 1600; j += 0.1f)
                    {
                        for (float k = 0; inequality1[0] * i + inequality1[1] * j + inequality1[2] * k < inequality1[3] && inequality2[0] * i + inequality2[1] * j + inequality2[2] * k < inequality2[3] &&
                            inequality3[0] * i + inequality3[1] * j + inequality3[2] * k < inequality3[3] && f3[0] * i + f3[1] * j + f3[2] * k <= 1600; k += 0.1f)
                        {
                            float res = f1[0] * i + f1[1] * j + f1[2] * k;

                            if (res > maxf && f2[0] * i + f2[1] * j + f2[2] * k >= 2400)
                            {
                                maxf = res;
                                x = new float[] { i, j, k };
                            }
                        }
                    }
                }
                maxf = MathF.Round(maxf, 1);
                for (int i = 0; i < x.Length; i++)
                {
                    x[i] = MathF.Round(x[i], 1);
                }

                Console.WriteLine($"Res = {maxf}");
                Console.WriteLine($"1-{x[0]}");
                Console.WriteLine($"2-{x[1]}");
                Console.WriteLine($"3-{x[2]}");
                Console.WriteLine();
            }

            Console.WriteLine("**************************Zad 3**************************");
            {
                int[] f1 = { 4, 3, 11 };
                int[] f2 = { 2, 4, 7 };
                int[] f3 = { 3, 5, 4 };
                int[] inequality1 = { 1, 2, 4, 150 };
                int[] inequality2 = { 3, 1, 2, 180 };
                int[] inequality3 = { 1, 2, 1, 240 };
                float[] w = { 0.3f, 0.5f, 0.2f };
                int p = 2;

                float resf1 = 0;
                float resf2 = 0;
                float resf3 = 0;

                float[] x = { 0, 0, 0 };

                for (float i = 0; inequality1[0] * i < inequality1[3] && inequality2[0] * i < inequality2[3] && inequality3[0] * i < inequality3[3] ; i += 0.1f)
                {
                    for (float j = 0; inequality1[0] * i + inequality1[1] * j < inequality1[3] && inequality2[0] * i + inequality2[1] * j < inequality2[3] &&
                        inequality3[0] * i + inequality3[1] * j < inequality3[3]; j += 0.1f)
                    {
                        for (float k = 0; inequality1[0] * i + inequality1[1] * j + inequality1[2] * k < inequality1[3] && inequality2[0] * i + inequality2[1] * j + inequality2[2] * k < inequality2[3] &&
                            inequality3[0] * i + inequality3[1] * j + inequality3[2] * k < inequality3[3]; k += 0.1f)
                        {
                            float res = f1[0] * i + f1[1] * j + f1[2] * k;

                            if (res > resf1)
                            {
                                resf1 = res;
                                x = new float[] { i, j, k };
                            }
                        }
                    }
                }

                for (float i = 0; inequality1[0] * i < inequality1[3] && inequality2[0] * i < inequality2[3] && inequality3[0] * i < inequality3[3]; i += 0.1f)
                {
                    for (float j = 0; inequality1[0] * i + inequality1[1] * j < inequality1[3] && inequality2[0] * i + inequality2[1] * j < inequality2[3] &&
                        inequality3[0] * i + inequality3[1] * j < inequality3[3]; j += 0.1f)
                    {
                        for (float k = 0; inequality1[0] * i + inequality1[1] * j + inequality1[2] * k < inequality1[3] && inequality2[0] * i + inequality2[1] * j + inequality2[2] * k < inequality2[3] &&
                            inequality3[0] * i + inequality3[1] * j + inequality3[2] * k < inequality3[3]; k += 0.1f)
                        {
                            float res = f2[0] * i + f2[1] * j + f2[2] * k;

                            if (res > resf2)
                            {
                                resf2 = res;
                                x = new float[] { i, j, k };
                            }
                        }
                    }
                }

                for (float i = 0; inequality1[0] * i < inequality1[3] && inequality2[0] * i < inequality2[3] && inequality3[0] * i < inequality3[3]; i += 0.1f)
                {
                    for (float j = 0; inequality1[0] * i + inequality1[1] * j < inequality1[3] && inequality2[0] * i + inequality2[1] * j < inequality2[3] &&
                        inequality3[0] * i + inequality3[1] * j < inequality3[3]; j += 0.1f)
                    {
                        for (float k = 0; inequality1[0] * i + inequality1[1] * j + inequality1[2] * k < inequality1[3] && inequality2[0] * i + inequality2[1] * j + inequality2[2] * k < inequality2[3] &&
                            inequality3[0] * i + inequality3[1] * j + inequality3[2] * k < inequality3[3]; k += 0.1f)
                        {
                            float res = f3[0] * i + f3[1] * j + f3[2] * k;

                            if (res > resf3)
                            {
                                resf3 = res;
                                x = new float[] { i, j, k };
                            }
                        }
                    }
                }

                resf1 = MathF.Round(resf1);
                resf2 = MathF.Round(resf2);
                resf3 = MathF.Round(resf3);

                Console.WriteLine($"~f1 = {resf1}");
                Console.WriteLine($"1-{x[0]}");
                Console.WriteLine($"2-{x[1]}");
                Console.WriteLine($"3-{x[2]}");
                Console.WriteLine();

                Console.WriteLine($"~f2 = {resf2}");
                Console.WriteLine($"1-{x[0]}");
                Console.WriteLine($"2-{x[1]}");
                Console.WriteLine($"3-{x[2]}");
                Console.WriteLine();

                Console.WriteLine($"~f3 = {resf3}");
                Console.WriteLine($"1-{x[0]}");
                Console.WriteLine($"2-{x[1]}");
                Console.WriteLine($"3-{x[2]}");
                Console.WriteLine();

                Console.WriteLine("(F(x),~F) = " + MathF.Sqrt(w[0] * MathF.Pow(0 - resf1, p) + w[1] * MathF.Pow(0 - resf2, p) + w[2] * MathF.Pow(0 - resf3, p)));
            }
        }
    }
}

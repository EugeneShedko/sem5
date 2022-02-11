using System;
using MathNet.Numerics.Statistics;
using MathNet.Numerics.LinearRegression;
using MathNet.Numerics.LinearAlgebra;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задание 1
            double[] x1 = { 6, 4.9, 7, 6.7, 5.8, 6.1, 5, 6.9, 6.8, 5.9 };
            double[] x2 = { 2, 0.8, 2.7, 3, 1, 2.1, 0.9, 2.6, 3, 1.1 };
            double[] x3 = { 25, 30, 20, 21, 28, 26, 30, 22, 20, 29};

            Console.WriteLine("Самостоятельное задание 1\n");
            Console.WriteLine(Correlation.PearsonMatrix(new double[][] { x1, x2, x3 }));

            //Задание 2

            double[] inflationLevel = { 84, 45, 56, 34, 23 };
            double[] refinancingRate = { 85, 55, 65, 40, 28 };
            double[] dollarRate = { 441, 980, 1400, 1960, 2030 };

            Console.WriteLine("\nСамостоятельное задание 2\n");
            Console.WriteLine(Correlation.PearsonMatrix(new double[][] { inflationLevel, refinancingRate, dollarRate }));

            //Задание 4

            double[] X1 = { 11, 19, 13, 14, 11, 17, 23, 11, 13, 20, 15 };
            double[] X2 = { 20, 14, 12, 8, 10, 6, 16, 15, 8, 17, 12 };
            double[] X3 = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            double[] Y = { 1.3, 2.3, 1.8, 1.4, 1.1, 1.2, 2.7, 1.9, 1.5, 2.1, 1.7 };

            Matrix<double> matrixX1 = Matrix<double>.Build.Dense(11, 1, X1);
            Matrix<double> matrixX2 = Matrix<double>.Build.Dense(11, 1, X2);
            Matrix<double> matrixX3 = Matrix<double>.Build.Dense(11, 1, X3);
            Matrix<double> matrixTask4Y = Matrix<double>.Build.Dense(11, 1, Y);

            matrixX1 = matrixX1.Append(matrixX2);
            matrixX1 = matrixX1.Append(matrixX3);

            Console.WriteLine("\nСамостоятельная работа\n");
            Matrix<double> regressionCoefficient = MultipleRegression.DirectMethod(matrixX1, matrixTask4Y);
            Console.WriteLine(regressionCoefficient);

            double[] arrayValues = { regressionCoefficient.At(0, 0), regressionCoefficient.At(1, 0), regressionCoefficient.At(2, 0) };
            Console.WriteLine("Прогноз накоплений при доходе=15 и имущество=18: " + (arrayValues[0] + arrayValues[1]*15 + arrayValues[2]*18));

            Console.WriteLine("Увеличаться на : " + arrayValues[1] * 5);
            Console.WriteLine("Уменьшатся на: " + (arrayValues[1] * 3 + arrayValues[2] * 5));
            Console.WriteLine("Увеличаться на: " + arrayValues[1] * ((15 * 10) / 100) + "\n");
            Console.WriteLine(Correlation.PearsonMatrix(new double[][] { X1, X2, Y }));
            Console.WriteLine("Доход и накопление: \n" + Correlation.PearsonMatrix(new double[][] { X1, Y }));
            Console.WriteLine("Доход и имущество: \n" + Correlation.PearsonMatrix(new double[][] { X1, X2 }));

        }
    }
}

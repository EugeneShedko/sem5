using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            ShortestPathGraph g = new ShortestPathGraph();
            Regex regex = new Regex(@"^(\d+)(\t(\d+),(\d+))+");
            string line;
            using (StreamReader srStreamRdr = new StreamReader(@"C:\projects\C#\Coursera\algorithms-graphs\week2\dijkstraData.txt"))
            {
                while ((line = srStreamRdr.ReadLine()) != null)
                {
                    var x = regex.Matches(line);
                    int first = int.Parse(x[0].Groups[1].Captures[0].Value);
                    for (int i=0; i<x[0].Groups[3].Captures.Count; i += 1)
                    {
                        int second = int.Parse(x[0].Groups[3].Captures[i].Value);
                        int length = int.Parse(x[0].Groups[4].Captures[i].Value);
                        g.AddEdge(first, second, length);
                    }
                }
            }
            g.GenerateShortestPathsFrom(1);
            Console.WriteLine($"{g.GetShortestPathTo(7)},"
                            + $"{g.GetShortestPathTo(37)},"
                            + $"{g.GetShortestPathTo(59)},"
                            + $"{g.GetShortestPathTo(82)},"
                            + $"{g.GetShortestPathTo(99)},"
                            + $"{g.GetShortestPathTo(115)},"
                            + $"{g.GetShortestPathTo(133)},"
                            + $"{g.GetShortestPathTo(165)},"
                            + $"{g.GetShortestPathTo(188)},"
                            + $"{g.GetShortestPathTo(197)}"
                            );
            Console.ReadKey();
        }
    }
}

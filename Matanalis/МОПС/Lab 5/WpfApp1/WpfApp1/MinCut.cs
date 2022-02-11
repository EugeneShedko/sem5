using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class MinCut
    {
        private static bool bfs(int[,] rGraph, int s,
                                int t, int[] parent)
        {
            bool[] visited = new bool[rGraph.Length];
  
            Queue<int> q = new Queue<int>();
            q.Enqueue(s);
            visited[s] = true;
            parent[s] = -1;

            while (q.Count != 0)
            {
                int v = q.Dequeue();
                for (int i = 0; i < rGraph.GetLength(0); i++)
                {
                    if (rGraph[v, i] > 0 && !visited[i])
                    {
                        q.Enqueue(i);
                        visited[i] = true;
                        parent[i] = v;
                    }
                }
            }

            return (visited[t] == true);
        }

        private static void dfs(int[,] rGraph, int s,
                                bool[] visited)
        {
            visited[s] = true;
            for (int i = 0; i < rGraph.GetLength(0); i++)
            {
                if (rGraph[s, i] > 0 && !visited[i])
                {
                    dfs(rGraph, i, visited);
                }
            }
        }

        public string[,] minCut(MainWindow mw,int[,] graph, int s, int t)
        {
            int u, v;
            int[,] rGraph = new int[graph.Length, graph.Length];
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    rGraph[i, j] = graph[i, j];
                }
            }

            int[] parent = new int[graph.Length];

            while (bfs(rGraph, s, t, parent))
            {
                int pathFlow = int.MaxValue;
                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    pathFlow = Math.Min(pathFlow, rGraph[u, v]);
                }

                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    rGraph[u, v] = rGraph[u, v] - pathFlow;
                    rGraph[v, u] = rGraph[v, u] + pathFlow;
                }
            }

            bool[] isVisited = new bool[graph.Length];
            dfs(rGraph, s, isVisited);

            string[,] result = new string[t + 1, t + 1];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    if (graph[i, j] > 0 && isVisited[i] && !isVisited[j])
                    {
                        result[i, j] = i + "-" + j;

                        Console.WriteLine(result[i, j]);
                        mw.TextBlockZad2.Text += i + " - " + j + "\n";
                    }
                }
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Dijkstra
{
	class Program
	{
		static void Main(string[] args)
		{
			List<List<int>> graph = new List<List<int>>();
			//  A B C D E F
			//A 0 2 0 4 0 0
			//B 2 0 5 0 3 0
			//C 0 5 0 0 0 4
			//D 4 0 0 0 5 0
			//E 0 3 0 5 0 6
			//F 0 0 4 0 6 0
			graph.Add(new List<int> { 0, 2, -1, 4, -1, -1 });
			graph.Add(new List<int> { 2, -1, 5, -1, 3, -1 });
			graph.Add(new List<int> { -1, 5, -1, -1, -1, 4 });
			graph.Add(new List<int> { 4, -1, -1, -1, 5, -1 });
			graph.Add(new List<int> { -1, 3, -1, 5, -1, 6 });
			graph.Add(new List<int> { -1, -1, 4, -1, 6, -1 });

			PrintGraph(graph);

			Dijkstra(graph, 0, 0);
		}


		static void PrintGraph(List<List<int>> graph)
		{
			for (int i = 0; i < graph.Count; i++)
			{
				Console.Write("Vertex " + i + " is connected to: ");
				for (int j = 0; j < graph[i].Count; j++)
				{
					if (graph[i][j] > 0)
					{
						Console.Write($"{j}({graph[i][j]}) ");
						//Console.Write(graph[i][j] + " ");
					}
				}
				Console.WriteLine();
			}
		}

		private static void Print(List<int> distance, int verticesCount)
		{
			Console.WriteLine("\nVertex    Distance from source");

			for (int i = 0; i < verticesCount; ++i)
				Console.WriteLine("{0}\t  {1}", i, distance[i]);
		}

		static void Dijkstra(List<List<int>> graph, int sourceX, int sourceY)
		{
			//start stopwatch to get runtime
			var watch = Stopwatch.StartNew();

			List<int> distances = new List<int>();
			List<bool> shortestPathSet = new List<bool>();

			//set all edges distance to max value
			for (int i = 0; i < graph.Count; i++)
			{
				distances.Add(int.MaxValue);
				shortestPathSet.Add(false);
			}

			//set source vertex distance to 0
			distances[sourceX] = 0;

			for (int i = 0; i < graph.Count; i++)
			{
				//get minimum distance index
				var temp = Minimum(distances, shortestPathSet, graph.Count);

				//this is discovered now so set to true
				shortestPathSet[i] = true;

				for (int j = 0; j < graph.Count; j++)
				{
					if (!shortestPathSet[j]
						&& graph[temp][j] > 0
						&& distances[temp] != int.MaxValue
						&& distances[temp] + graph[temp][j] <= distances[j])
					{
						distances[j] = distances[temp] + graph[temp][j];
					}

				}
			}

			//stop runtime stopwatch
			watch.Stop();

			//print all distances from source
			Print(distances, graph.Count);

			//write elapsed ms of dijkstra's
			Console.WriteLine($"\nRuntime: {watch.Elapsed.TotalMilliseconds}ms");
		}

		//gets index of minimum distance
		static int Minimum(List<int> distances, List<bool> shortestPathSet, int graphCount)
		{
			int min = int.MaxValue;
			int minIndex = -1;

			for (int i = 0; i < graphCount; i++)
			{
				if (shortestPathSet[i] == false && distances[i] <= min)
				{
					min = distances[i];
					minIndex = i;
				}
			}

			return minIndex;
		}

	}
}

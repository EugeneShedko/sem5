using System;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra_s_Algorithm
{
    public class DijkstrasAlgorithmWithHeuristics
    {
        public DijkstrasAlgorithmWithHeuristics()
        {
        }

        /// <summary>
        /// An implementation of Dijkstra's Algorithm and A* (when heuristics are considered)
        /// PSEUDOCODE format followed to make this implementation:
        /// http://www.gitta.info/Accessibiliti/en/html/Dijkstra_learningObject1.html
        /// AND
        /// https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="start"></param>
        /// <param name="end"> Can be null as long as a goal node is specified</param>
        /// <returns></returns>
        public List<Vertex> SearchForShortestPath(Graph graph, Vertex start)
        {
            if (graph == null)
            {
                throw new ArgumentNullException("Input graph is null.");
            }

            if (start == null)
            {
                throw new ArgumentNullException("Specified start or end vertices are null.");
            }

            if (!graph.HasVertex(start))
            {
                throw new ArgumentNullException("No start vertex has been found in the input graph.");
            }

            IDictionary<Vertex, Vertex> previous = new Dictionary<Vertex, Vertex>();
            IDictionary<Vertex, int> distance = new Dictionary<Vertex, int>();
            List<Vertex> priorityQueue = new List<Vertex>();

            foreach (var vertex in graph.Vertices)
            {
                distance[vertex] = int.MaxValue;
                previous[vertex] = null;
                priorityQueue.Add(vertex);
            }

            distance[start] = 0;
            List<Vertex> path = new List<Vertex>();
                 
            while (priorityQueue.Any())
            {
                priorityQueue.OrderBy(x => distance[x] + x.Heuristic).ToList();
                var currentSmallestVertex = priorityQueue.First();
                priorityQueue.Remove(currentSmallestVertex);

                if (currentSmallestVertex.IsGoal)
                {                 
                    while(previous[currentSmallestVertex] != null)
                    {      
                        path.Add(currentSmallestVertex);
                        currentSmallestVertex = previous[currentSmallestVertex];
                    }
                    path.Reverse();
                    return path;
                }
            
                foreach (var neighbour in currentSmallestVertex.Edges.OrderBy(x => x.Cost).ToList())
                {
                    var alt = distance[currentSmallestVertex] + neighbour.Cost + neighbour.destinationVertex.Heuristic;
                    if (alt < distance[neighbour.destinationVertex])
                    {
                        distance[neighbour.destinationVertex] = alt;
                        previous[neighbour.destinationVertex] = currentSmallestVertex;                      
                    }
                }
            }

            path.Reverse();
            return path;
        }
    }
}

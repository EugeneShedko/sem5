using System;
using System.Collections.Generic;

namespace Dijkstra_s_Algorithm
{
    public class Graph
    {
        public List<Vertex> Vertices { get; set; }

        public Graph()
        {
            Vertices = new List<Vertex>();
        }

        /// <summary>
        /// Basic operation on adding a new vertex
        /// </summary>
        /// <param name="vertex"></param>
        public void AddVertex(Vertex vertex)
        {
            Vertices.Add(vertex);
        }

        /// <summary>
        /// Adds a whole list of vertices
        /// </summary>
        /// <param name="vertices"></param>
        public void AddVertices(List<Vertex> vertices)
        {
            if (Vertices.Count > 0)
            {
                foreach (var vertex in vertices)
                {
                    Vertices.Add(vertex);
                }
            }
            else
            {
                Vertices = vertices;
            }
        }

        /// <summary>
        /// Remove a vertex
        /// </summary>
        /// <param name="vertex"></param>
        public void RemoveVertex(Vertex vertex)
        {
            if (Vertices.Contains(vertex))
            {
                Vertices.Remove(vertex);
            }
            else
            {
                throw new NullReferenceException("The vertex specified cannot be found during removal.");
            }
        }

        /// <summary>
        /// Returns true if vertex is in graph.
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public bool HasVertex(Vertex vertex)
        {
            return Vertices.Contains(vertex);
        }
    }
}

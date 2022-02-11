using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra
{
    public class ShortestPathGraph
    {
        const int INFINITY = 1000000;
        private Dictionary<int, Vertex> vertexList;
        private Dictionary<int, int> shortestPaths;
        private int size;

        public ShortestPathGraph()
        {
            vertexList = new Dictionary<int, Vertex>();
        }

        public void AddEdge(int first, int second, int length)
        {
            if (!vertexList.ContainsKey(first))
            {
                vertexList.Add(first, new Vertex(first));
                size += 1;
            }
            if (!vertexList.ContainsKey(second))
            {
                vertexList.Add(second, new Vertex(second));
                size += 1;
            }
            vertexList[first].AddOutNeighbor(second, length);
            vertexList[second].AddOutNeighbor(first, length);
        }

        public void GenerateShortestPathsFrom(int index)
        {
            int currentIndex;
            Vertex currentVertex;
            HashSet<int> visited = new HashSet<int>();
            MinHeap<int> lengthHeap = new MinHeap<int>();
            shortestPaths = new Dictionary<int, int>();
            foreach (Vertex v in vertexList.Values)
            {
                if (v.index == index)
                {
                    shortestPaths.Add(v.index, 0);
                    lengthHeap.Add(0,v.index);
                }
                else
                {
                    shortestPaths.Add(v.index, INFINITY);
                }
            }
            while (visited.Count < size)
            {
                currentIndex = lengthHeap.ExtractMin().Item2;
                currentVertex = vertexList[currentIndex];
                foreach(var (outIndex, outLength) in currentVertex.outNeighbors)
                {
                    if (!visited.Contains(outIndex))
                    {
                        int tentativeLength = shortestPaths[currentIndex] + outLength;
                        if (shortestPaths[outIndex] > tentativeLength)
                        {
                            shortestPaths[outIndex] = tentativeLength;
                            lengthHeap.Add(tentativeLength, outIndex);
                        }
                    }
                }
                visited.Add(currentIndex);
            }
        }

        public int GetShortestPathTo(int index)
        {
            return shortestPaths[index];
        }

    }
}

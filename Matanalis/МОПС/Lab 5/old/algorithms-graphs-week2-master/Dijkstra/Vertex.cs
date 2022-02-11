using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra
{
    internal class Vertex
    {
        public int index { get; }
        public List<(int, int)> outNeighbors { get; }

        public Vertex(int myIndex)
        {
            index = myIndex;
            outNeighbors = new List<(int,int)>();
        }

        public void AddOutNeighbor(int neighborIndex, int length)
        {
            outNeighbors.Add((neighborIndex, length));
        }
    }
}

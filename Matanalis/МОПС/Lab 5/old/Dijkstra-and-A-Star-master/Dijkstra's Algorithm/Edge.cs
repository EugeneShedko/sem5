using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_s_Algorithm
{
    public class Edge
    {
        internal int Cost { get; set; }
        internal Vertex destinationVertex { get; set; }

        public Edge(int cost, Vertex destination)
        {
            Cost = cost;
            destinationVertex = destination;
        }

    }
}

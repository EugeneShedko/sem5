using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Dijkstra_s_Algorithm
{
    public class Vertex
    {
        public string Name { get; set; }
        internal List<Edge> Edges { get; set; }
        internal int Heuristic { get; set; }
        internal bool IsGoal { get; set; }

        public Vertex(string name, int? heuristic, List<Edge> edges, bool isGoal = false)
        {
            Name = name;
            Edges = edges ?? new List<Edge>();
            Heuristic = heuristic ?? 0;
            IsGoal = isGoal;
        }
    }
}
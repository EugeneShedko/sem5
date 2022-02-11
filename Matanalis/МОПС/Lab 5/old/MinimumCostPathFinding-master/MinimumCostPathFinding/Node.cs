using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumCostPathFinding
{
    class Node
    {
        public int hotelCost { get; set; }
        public string name { get; set; }
        public Node(int hotel,string name, int[] petrols)
        {
            hotelCost = hotel;
            this.name = name;
            petrolCosts = petrols;
        }
        public int[] petrolCosts { get; set; }
    }
}

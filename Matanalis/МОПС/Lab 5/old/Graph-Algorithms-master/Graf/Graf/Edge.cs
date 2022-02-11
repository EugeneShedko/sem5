using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graf
{
    public class Edge
    {
        public Kose kose1;
        public Kose kose2;
        public int distance;
        public bool durum = false;


        public Edge()
        {
            kose1 = new Kose();
            kose2 = new Kose();
        }
    }
}

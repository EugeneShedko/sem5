using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graf
{
    public class Kose
    {
        public string data;
        public List<Edge> Edges;
        public bool ziyaretDurumu = false;
        public bool kenarZiyeretDurumu = false;
        public int maliyet;

        public Kose()
        {
            Edges = new List<Edge>();
            maliyet = int.MaxValue;
        }

        public void KenarEkle(List<Edge> kenarlar)
        {
            Edges = kenarlar;
        }


    }
}

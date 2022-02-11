using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graf
{
    public class Graph
    {
        public List<Kose> Koseler = new List<Kose>();
        public List<Edge> Kenarlar = new List<Edge>();

        
        
        public void KoseEkle(Kose kose)
        {
            Koseler.Add(kose);
        }

        string strDFS = "";
        

        public string DFS(Kose kose)
        { 
            if(!kose.ziyaretDurumu)
            {
                Visit(kose);

                foreach (Edge item in kose.Edges)
                {
                    if (item.kose2 == kose)
                    {
                        if (!item.kose1.ziyaretDurumu)
                        { 
                            strDFS += item.kose1.data + "  ";
                            DFS(item.kose1);
                        }
                        
                    }
                    else
                    {
                        if (!item.kose2.ziyaretDurumu)
                        {
                            strDFS += item.kose2.data + "  ";
                            DFS(item.kose2);
                        }          
                    }

                }
                
            }
            return strDFS;

        }
        public void Visit(Kose kose)
        {
            kose.ziyaretDurumu = true;
        }
        public void DurumDegistir()
        {
            foreach (Kose kose in Koseler)
            {
                kose.ziyaretDurumu = false;
                kose.kenarZiyeretDurumu = false;
            }
        }
        public string BFS(Edge edge,Kose kose)
        {
            string strBFS = "";
            if (edge.kose2 == kose)
            {
                if (!edge.kose1.ziyaretDurumu)
                {
                    strBFS = edge.kose1.data+"  ";
                    edge.kose1.ziyaretDurumu = true;
                }

            }
            else
            {
                if (!edge.kose2.ziyaretDurumu)
                {
                    strBFS = edge.kose2.data+"  ";
                    edge.kose2.ziyaretDurumu = true;
                }
            }
            return strBFS;
        }
        public void KenarlariSirala()
        {
            int minIndis = 0;
            for (int i = 0; i < Kenarlar.Count; i++)
            {
                minIndis = i;

                for (int j = i + 1; j < Kenarlar.Count; j++)
                {
                    if (Kenarlar[j].distance < Kenarlar[minIndis].distance)
                        minIndis = j;
                }

                if(minIndis!=i)
                {
                    Edge temp = Kenarlar[i];
                    Kenarlar[i] = Kenarlar[minIndis];
                    Kenarlar[minIndis] = temp;
                }
            }    
        }


        public string Kruskal()
        {
            string strKruskal = "";
            int maliyet = 0;
            Kose temp = new Kose();


            foreach (Edge edge in Kenarlar)
            {

                if (!edge.kose1.ziyaretDurumu || !edge.kose2.ziyaretDurumu || (!edge.kose1.ziyaretDurumu && !edge.kose2.ziyaretDurumu))
                {
                    edge.kose2.ziyaretDurumu = true;
                    edge.kose1.ziyaretDurumu = true;
                    edge.durum = true;
                    strKruskal += edge.kose1.data + " - " + edge.kose2.data + " : " + edge.distance+" --> "+ Environment.NewLine;
                    maliyet += edge.distance;
                }
            }
            strKruskal += "Maliyet : "+maliyet;
            return strKruskal;
        }

        public void Dijkstra(Kose kose)
        {
            foreach (Edge edge in kose.Edges)
            {
                if (kose == edge.kose1)
                {
                    int yeniMaliyet = edge.distance + edge.kose1.maliyet;

                    if (!edge.kose2.ziyaretDurumu)
                    {
                        if (edge.kose2.maliyet > yeniMaliyet)
                        {
                            edge.kose2.maliyet = yeniMaliyet;
                            edge.kose2.ziyaretDurumu = true;
                        }
                        Dijkstra(edge.kose2);

                    }
                    else if (edge.kose2.maliyet > yeniMaliyet)
                    {
                        edge.kose2.maliyet = yeniMaliyet;
                        Dijkstra(edge.kose2);
                    }
                }
                else
                {
                    int yeniMaliyet = edge.distance + edge.kose2.maliyet;
                    if (!edge.kose1.ziyaretDurumu)
                    {

                        if (edge.kose1.maliyet > yeniMaliyet)
                        {
                            edge.kose1.maliyet = yeniMaliyet;
                            edge.kose1.ziyaretDurumu = true;
                        }
                        Dijkstra(edge.kose1);


                    }
                    else if (edge.kose1.maliyet > yeniMaliyet)
                    {
                        edge.kose1.maliyet = yeniMaliyet;
                        Dijkstra(edge.kose1);
                    }
                }
            }
        }
        List<Edge> KenarPrim = new List<Edge>();
        int index=0,Enkucuk;
        string get = "";
        public string Prims(Kose kose,Edge edge)
        {  
            Edge tempkenar= new Edge();
            if(kose.data=="A")
                get += edge.kose1.data+"- "+edge.kose2.data +"    ";
            else if(kose.data!="D")
                get += edge.kose2.data + "-" + edge.kose1.data + "    ";

            foreach (Edge kenar in kose.Edges)
            {  
                if (!kenar.kose1.ziyaretDurumu || !kenar.kose2.ziyaretDurumu  || (!kenar.kose1.ziyaretDurumu && !kenar.kose2.ziyaretDurumu))
                KenarPrim.Add(kenar); 
                
            }
            Enkucuk = int.MaxValue;
            foreach (Edge kenar in KenarPrim)
            {
                if (kenar.kose1.ziyaretDurumu && kenar.kose2.ziyaretDurumu)
                {
                    continue;                 
                }
                else
                {
                    if (kenar.distance <= Enkucuk)
                    {
                        tempkenar = kenar;
                        Enkucuk = kenar.distance;
                    }
                }
               
            }
            
            if (tempkenar.kose1.ziyaretDurumu)
            {
                tempkenar.kose2.ziyaretDurumu = true;
                KenarPrim.Remove(tempkenar);
                Prims(tempkenar.kose2,tempkenar);
            }
            else if(tempkenar.kose2.ziyaretDurumu)
            {   
                tempkenar.kose1.ziyaretDurumu = true;
                KenarPrim.Remove(tempkenar);
                Prims(tempkenar.kose1,tempkenar);
            }

            return get;
        }
    }
}

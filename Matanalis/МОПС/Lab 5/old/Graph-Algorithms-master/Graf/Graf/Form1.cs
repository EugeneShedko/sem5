using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Graph graf = new Graph();
        Kose A = new Kose();
        Kose B = new Kose();
        Kose C = new Kose();
        Kose D = new Kose();
        Kose E = new Kose();
        Kose F = new Kose();
        Kose G = new Kose();
        Kose H = new Kose();


        Edge A_D = new Edge();
        Edge A_C = new Edge();
        Edge C_G = new Edge();
        Edge G_E = new Edge();
        Edge E_D = new Edge();
        Edge D_H = new Edge();
        Edge H_E = new Edge();
        Edge H_F = new Edge();
        Edge F_B = new Edge();
        Edge B_D = new Edge();

        Graph SosyalAg = new Graph();
        Kose Doktor = new Kose();
        Kose Subay = new Kose();
        Kose Muhendis = new Kose();
        Kose Mimar = new Kose();
        Kose Prof = new Kose();
        Kose Politikaci = new Kose();

        Edge Dok_Muh = new Edge();
        Edge Dok_Sub = new Edge();
        Edge Dok_Prof = new Edge();
        Edge Sub_Mim = new Edge();
        Edge Sub_Prof = new Edge();
        Edge Mim_Prof = new Edge();
        Edge Mim_Pol = new Edge();
        Edge Prof_Muh = new Edge();
        Edge Prof_Pol = new Edge();
        Edge Muh_Pol = new Edge();
        private void Form1_Load(object sender, EventArgs e)
        {
           

            graf.KoseEkle(A);
            graf.KoseEkle(B);
            graf.KoseEkle(C);
            graf.KoseEkle(D);
            graf.KoseEkle(E);
            graf.KoseEkle(F);
            graf.KoseEkle(G);
            graf.KoseEkle(H);

            A.data = "A";
            A.maliyet = 0;
            B.data = "B";
            C.data = "C";
            D.data = "D";
            E.data = "E";
            F.data = "F";
            G.data = "G";
            H.data = "H";



            A_D.kose1 = A;
            A_D.kose2 = D;
            A_D.distance = 2;

            A_C.kose1 = A;
            A_C.kose2 = C;
            A_C.distance = 5;

            C_G.kose1 = C;
            C_G.kose2 = G;
            C_G.distance = 4;

            G_E.kose1 = G;
            G_E.kose2 = E;
            G_E.distance = 5;

            E_D.kose1 = E;
            E_D.kose2 = D;
            E_D.distance = 3;

            B_D.kose1 = B;
            B_D.kose2 = D;
            B_D.distance = 4;

            F_B.kose1 = F;
            F_B.kose2 =B;
            F_B.distance = 8;

            H_F.kose1 = H;
            H_F.kose2 = F;
            H_F.distance = 6;

            H_E.kose1 = H;
            H_E.kose2 = E;
            H_E.distance = 2;

            D_H.kose1 = D;
            D_H.kose2 = H;
            D_H.distance = 7;

            A.Edges.Add(A_D);
            A.Edges.Add(A_C);

            B.Edges.Add(B_D);
            B.Edges.Add(F_B);

            C.Edges.Add(C_G);
            C.Edges.Add(A_C);

            D.Edges.Add(A_D);
            D.Edges.Add(E_D);
            D.Edges.Add(B_D);
            D.Edges.Add(D_H);

            E.Edges.Add(H_E);
            E.Edges.Add(E_D);
            E.Edges.Add(G_E);

            F.Edges.Add(H_F);
            F.Edges.Add(F_B);

            G.Edges.Add(C_G);
            G.Edges.Add(G_E);

            H.Edges.Add(H_E);
            H.Edges.Add(H_F);
            H.Edges.Add(D_H);

            
            //string str = A.data +"  "+ graf.DFS(A);
            //MessageBox.Show(str);

            
            foreach (Kose kose in graf.Koseler)
            {
                kose.kenarZiyeretDurumu = true;
                foreach (Edge edge in kose.Edges)
                {
                    if (edge.kose2 == kose)
                    {
                        if (!edge.kose1.kenarZiyeretDurumu)
                            graf.Kenarlar.Add(edge);
                    }
                    else
                    {
                        if (!edge.kose2.kenarZiyeretDurumu)
                            graf.Kenarlar.Add(edge);
                    }
                }
            }
            graf.KenarlariSirala();

            //string tmp = "";
            //foreach (Edge edge in graf.Kenarlar)
            //{
            //    tmp += edge.distance + " ";
            //}
            //MessageBox.Show(tmp);

           
            
           
            // Soru 7 nin Grafı oluşturuluyor
           

            Doktor.data = "Doktor";
            Subay.data = "Subay";
            Muhendis.data = "Muhendis";
            Mimar.data = "Mimar";
            Prof.data = "Prof";
            Politikaci.data = "Politikaci";

           

            Dok_Muh.distance = 5;
            Dok_Muh.kose1 = Doktor;
            Dok_Muh.kose2 = Muhendis;

            Dok_Sub.distance = 12;
            Dok_Sub.kose1 = Doktor;
            Dok_Sub.kose2 = Subay;

            Dok_Prof.distance = 8;
            Dok_Prof.kose1 = Doktor;
            Dok_Prof.kose2 = Prof;

            Sub_Prof.distance = 7;
            Sub_Prof.kose1 = Subay;
            Sub_Prof.kose2 = Prof;

            Sub_Mim.distance = 9;
            Sub_Mim.kose1 = Subay;
            Sub_Mim.kose2 = Mimar;

            Mim_Prof.distance = 4;
            Mim_Prof.kose1 = Mimar;
            Mim_Prof.kose2 = Prof;

            Mim_Pol.distance = 15;
            Mim_Pol.kose1 = Mimar;
            Mim_Pol.kose2 = Politikaci;

            Prof_Muh.distance = 6;
            Prof_Muh.kose1 = Prof;
            Prof_Muh.kose2 = Muhendis;
            Prof_Pol.distance = 16;
            Prof_Pol.kose1 = Prof;
            Prof_Pol.kose2 = Politikaci;

            Muh_Pol.distance = 10;
            Muh_Pol.kose1 = Muhendis;
            Muh_Pol.kose2 = Politikaci;

            Doktor.Edges.Add(Dok_Muh);
            Doktor.Edges.Add(Dok_Sub);
            Doktor.Edges.Add(Dok_Prof);

            Subay.Edges.Add(Dok_Sub);
            Subay.Edges.Add(Sub_Mim);
            Subay.Edges.Add(Sub_Prof);

            Mimar.Edges.Add(Sub_Mim);
            Mimar.Edges.Add(Mim_Prof);
            Mimar.Edges.Add(Mim_Pol);

            Prof.Edges.Add(Dok_Prof);
            Prof.Edges.Add(Sub_Prof);
            Prof.Edges.Add(Mim_Prof);
            Prof.Edges.Add(Prof_Muh);
            Prof.Edges.Add(Prof_Pol);

            Muhendis.Edges.Add(Dok_Muh);
            Muhendis.Edges.Add(Prof_Muh);
            Muhendis.Edges.Add(Muh_Pol);

            Politikaci.Edges.Add(Muh_Pol);
            Politikaci.Edges.Add(Mim_Pol);
            Politikaci.Edges.Add(Prof_Pol);

            SosyalAg.Koseler.Add(Doktor);
            SosyalAg.Koseler.Add(Muhendis);
            SosyalAg.Koseler.Add(Mimar);
            SosyalAg.Koseler.Add(Politikaci);
            SosyalAg.Koseler.Add(Prof);
            SosyalAg.Koseler.Add(Subay);

            SosyalAg.Kenarlar.Add(Dok_Muh);
            SosyalAg.Kenarlar.Add(Dok_Prof);
            SosyalAg.Kenarlar.Add(Dok_Sub);
            SosyalAg.Kenarlar.Add(Sub_Prof);
            SosyalAg.Kenarlar.Add(Sub_Mim);
            SosyalAg.Kenarlar.Add(Mim_Prof);
            SosyalAg.Kenarlar.Add(Mim_Pol);
            SosyalAg.Kenarlar.Add(Prof_Muh);
            SosyalAg.Kenarlar.Add(Prof_Pol);
            SosyalAg.Kenarlar.Add(Muh_Pol);

           

        }

        private void btnDijkstra_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox1.Visible = true;

            lboxKoseler.Items.Clear();
            graf.DurumDegistir();
            A.ziyaretDurumu = true;
            string strDijkstra = "";
            graf.Dijkstra(A);
            foreach (Kose kose in graf.Koseler)
            {
                strDijkstra = "A'dan " + kose.data + "'ye en kısa yol : " + kose.maliyet + Environment.NewLine;
                lboxKoseler.Items.Add(strDijkstra);
            }
        }

        private void btnBfs_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox1.Visible = true;

            lboxKoseler.Items.Clear();
            graf.DurumDegistir();
            A.ziyaretDurumu = true;
            string strBFS = A.data + "  ";
            foreach (Kose kose in graf.Koseler)
            {
                foreach (Edge edge in kose.Edges)
                {
                    if (kose.ziyaretDurumu)
                    {
                        strBFS += graf.BFS(edge, kose);
                    }
                }

            }
            lboxKoseler.Items.Add(strBFS);
        }

        private void btnPrim_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox1.Visible = true;

            lboxKoseler.Items.Clear();
            graf.DurumDegistir();
            A.ziyaretDurumu = true;
            lboxKoseler.Items.Add(graf.Prims(A, A_D));

        }

        private void btnKruskal_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox1.Visible = true;

            lboxKoseler.Items.Clear();
            graf.DurumDegistir();
            string strKruskal = "";
            strKruskal = graf.Kruskal();
            lboxKoseler.Items.Add(strKruskal);
        }

        private void btnSosyal_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
            lboxKoseler.Items.Clear();
            SosyalAg.DurumDegistir();
            Doktor.ziyaretDurumu = true;

            string getDijkstra = "";
            Doktor.maliyet = 0;
            SosyalAg.Dijkstra(Doktor);

            foreach (Kose kose in SosyalAg.Koseler)
            {
                getDijkstra = kose.data + "  ile  Doktor arasındaki en kısa yol : " + kose.maliyet + Environment.NewLine;
                lboxKoseler.Items.Add(getDijkstra) ;
            }
            


        }
    }
}

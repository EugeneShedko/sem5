using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoolProblem
{
    public partial class Pool : Form
    {
        public Pool()
        {
            InitializeComponent();
        }

        private void btnStartProcess_Click(object sender, EventArgs e)
        {
            richTextBoxResult.Text = "";
            //  int[,] graph = new int[,] {
            //                          {0, 16, 13, 0, 0, 0},
            //                          {0, 0, 10, 12, 0, 0},
            //                          {0, 4, 0, 0, 14, 0},
            //                          {0, 0, 9, 0, 0, 20},
            //                          {0, 0, 0, 7, 0, 4},
            //                          {0, 0, 0, 0, 0, 0}
            //};

            int start = Convert.ToInt32(numericUpDownStart.Value);
            int end = Convert.ToInt32(numericUpDownEnd.Value);

            int[,] graph = new int[end + 1, end + 1];

            string[] parcalar;

            char[] yildiz = { '*' };
            char[] virgul = { ',' };

            string test = richTextBoxEdges.Text.Replace("},", "*");
            test = test.Replace("}", "");
            test = test.Replace("{", "");
            test = test.Replace(" ", "");

            parcalar = test.Split(yildiz);

            for (int i = 0; i < parcalar.Length; i++)
            {
                string[] sayilar = parcalar[i].Split(virgul);
                for (int j = 0; j < sayilar.Length; j++)
                {
                    graph[i, j] = Convert.ToInt32(sayilar[j]);
                }
            }

            MaxFlow mF = new MaxFlow();

            //richTextBoxResult.Text = mF.CallMethod(graph, start, end);
            int result = mF.fordFulkerson(graph, start, end);
            richTextBoxResult.Text = "The maximum possible flow is " + result + "\n";

            MinCut mC = new MinCut();
           string [,] gelenDegerler = mC.minCut(graph, start, end);

            richTextBoxResult.Text += "MinCut Değerleri : \n";
            foreach (var item in gelenDegerler)
            {
                if (item!=null && item!="")
                {
                    richTextBoxResult.Text += item + "\n";
                }
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] s1 = { "", "", "", "", "", "", "" };
            string[] s2 = { "", "", "", "", "", "", "" };
            string[] colors1 = new string[7];
            string[] colors2 = new string[7];
            string[] comb1 = textBox1.Lines, comb2 = textBox2.Lines;
            int n1 = Convert.ToInt32(comb1[0]);
            int n2 = Convert.ToInt32(comb2[0]);
            char[] charColors = { 'R', 'O', 'Y', 'G', 'C', 'B', 'P' };
            string[] nameColors = { "#FF5B58", "#FFAC40", "#FFF650", "#8DFF70", "#97FFF3", "#7F8CFF", "#A978FF" };
            int max1, nmax1, max2, nmax2, nres, num;
            string col;

            for (int i = 0; i < 7; i++)
            {
                colors1[i] = "#FFFFFF";
                colors2[i] = "#FFFFFF";
            }
            for (int i = 0; i < n1; i++)
            {
                s1[i] = Convert.ToString(comb1[i + 1][0]);
                char c = comb1[i + 1][2];
                int ind = 0;
                for (int j = 0; j < 7; j++)
                {
                    if (c == charColors[j])
                    {
                        ind = j;
                        break;
                    }
                }
                colors1[i] = nameColors[ind];
            }
            for (int i = 0; i < n2; i++)
            {
                s2[i] = Convert.ToString(comb2[i + 1][0]);
                char c = comb2[i + 1][2];
                int ind = 0;
                for (int j = 0; j < 7; j++)
                {
                    if (c == charColors[j])
                    {
                        ind = j;
                        break;
                    }
                }
                colors2[i] = nameColors[ind];
            }
            max1 = Convert.ToInt32(s1[0]);
            nmax1 = 0;
            for (int i = 1; i < n1; i++)
            {
                if (Convert.ToInt32(s1[i]) > max1)
                {
                    max1 = Convert.ToInt32(s1[i]);
                    nmax1 = i;
                }
                if (Convert.ToInt32(s1[i]) == max1)
                {
                    int ind1 = 0, ind2 = 0;
                    for (int j = 0; j < nameColors.Length; j++)
                    {
                        if (nameColors[j] == colors1[i])
                            ind1 = j;
                        if (nameColors[j] == colors1[nmax1])
                            ind2 = j;
                    }
                    nmax1 = ind1 < ind2 ? i : nmax1;
                    max1 = Convert.ToInt32(s1[nmax1]);
                }
            }
            max2 = Convert.ToInt32(s2[0]);
            nmax2 = 0;
            for (int i = 1; i < n2; i++)
            {
                if (Convert.ToInt32(s2[i]) > max2)
                {
                    max2 = Convert.ToInt32(s2[i]);
                    nmax2 = i;
                }
                if (Convert.ToInt32(s2[i]) == max2)
                {
                    int ind1 = 0, ind2 = 0;
                    for (int j = 0; j < nameColors.Length; j++)
                    {
                        if (nameColors[j] == colors2[i])
                            ind1 = j;
                        if (nameColors[j] == colors2[nmax1])
                            ind2 = j;
                    }
                    nmax2 = ind1 < ind2 ? i : nmax2;
                    max2 = Convert.ToInt32(s2[nmax2]);
                }
            }
            if (max1 > max2)
            {
                nres = 1;
                col = colors1[nmax1];
                num = Convert.ToInt32(s1[nmax1]);
            }
            else if (max1 == max2)
            {
                int ind1 = 0, ind2 = 0;
                for (int j = 0; j < nameColors.Length; j++)
                {
                    if (nameColors[j] == colors1[nmax1])
                        ind1 = j;
                    if (nameColors[j] == colors2[nmax2])
                        ind2 = j;
                }
                if (ind1 < ind2)
                {
                    nres = 1;
                    col = colors1[nmax1];
                    num = Convert.ToInt32(s1[nmax1]);
                }
                else
                {
                    nres = 2;
                    col = colors2[nmax2];
                    num = Convert.ToInt32(s2[nmax2]);
                }
            }
            else
            {
                nres = 2;
                col = colors2[nmax2];
                num = Convert.ToInt32(s2[nmax2]);
            }
            label3.Text = "Выиграла комбинация № " + nres;
            resCard.BackColor = ColorTranslator.FromHtml(col);
            resC.Text = Convert.ToString(num);
            // 1
            c11.Text = s1[0];
            c12.Text = s1[1];
            c13.Text = s1[2];
            c14.Text = s1[3];
            c15.Text = s1[4];
            c16.Text = s1[5];
            c17.Text = s1[6];
            card11.BackColor = ColorTranslator.FromHtml(colors1[0]);
            card12.BackColor = ColorTranslator.FromHtml(colors1[1]);
            card13.BackColor = ColorTranslator.FromHtml(colors1[2]);
            card14.BackColor = ColorTranslator.FromHtml(colors1[3]);
            card15.BackColor = ColorTranslator.FromHtml(colors1[4]);
            card16.BackColor = ColorTranslator.FromHtml(colors1[5]);
            card17.BackColor = ColorTranslator.FromHtml(colors1[6]);
            // 2
            c21.Text = s2[0];
            c22.Text = s2[1];
            c23.Text = s2[2];
            c24.Text = s2[3];
            c25.Text = s2[4];
            c26.Text = s2[5];
            c27.Text = s2[6];
            card21.BackColor = ColorTranslator.FromHtml(colors2[0]);
            card22.BackColor = ColorTranslator.FromHtml(colors2[1]);
            card23.BackColor = ColorTranslator.FromHtml(colors2[2]);
            card24.BackColor = ColorTranslator.FromHtml(colors2[3]);
            card25.BackColor = ColorTranslator.FromHtml(colors2[4]);
            card26.BackColor = ColorTranslator.FromHtml(colors2[5]);
            card27.BackColor = ColorTranslator.FromHtml(colors2[6]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            label3.Text = "Выиграла комбинация № ";
            resCard.BackColor = ColorTranslator.FromHtml("#F0F0F0");
            resC.Text = "";
            // 1
            c11.Text = "";
            c12.Text = "";
            c13.Text = "";
            c14.Text = "";
            c15.Text = "";
            c16.Text = "";
            c17.Text = "";
            card11.BackColor = ColorTranslator.FromHtml("#F0F0F0");
            card12.BackColor = ColorTranslator.FromHtml("#F0F0F0");
            card13.BackColor = ColorTranslator.FromHtml("#F0F0F0");
            card14.BackColor = ColorTranslator.FromHtml("#F0F0F0");
            card15.BackColor = ColorTranslator.FromHtml("#F0F0F0");
            card16.BackColor = ColorTranslator.FromHtml("#F0F0F0");
            card17.BackColor = ColorTranslator.FromHtml("#F0F0F0");
            // 2
            c21.Text = "";
            c22.Text = "";
            c23.Text = "";
            c24.Text = "";
            c25.Text = "";
            c26.Text = "";
            c27.Text = "";
            card21.BackColor = ColorTranslator.FromHtml("#F0F0F0");
            card22.BackColor = ColorTranslator.FromHtml("#F0F0F0");
            card23.BackColor = ColorTranslator.FromHtml("#F0F0F0");
            card24.BackColor = ColorTranslator.FromHtml("#F0F0F0");
            card25.BackColor = ColorTranslator.FromHtml("#F0F0F0");
            card26.BackColor = ColorTranslator.FromHtml("#F0F0F0");
            card27.BackColor = ColorTranslator.FromHtml("#F0F0F0");
        }
    }
}

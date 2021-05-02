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
    /*
    public enum Colors
    {
        R = 0,
        O = 1,
        Y = 2,
        G = 3,
        C = 4,
        B = 5,
        P = 6
    }*/
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public void readData(ref bool isDataCorrect, int combLen, string[] comb, List<int> nomOfCards, TextBox textBox, char[] charColors, List<string> colors, string[] codeOfColors)
        {
            const int maxLength = 7, nomPosition = 0, colorPosition = 2;
            for (int i = 0; i < combLen; i++)
            {
                int num;
                bool result1 = int.TryParse(Convert.ToString(comb[i][nomPosition]), out num);
                if (!result1)
                {
                    textBox.ForeColor = Color.Red;
                    textBox.Text = "\nError!";
                    isDataCorrect = false;
                }
                else
                {
                    int nom = Convert.ToInt32(comb[i][nomPosition]) - 48;
                    if (nom > 7 || nom < 1)
                    {
                        textBox.ForeColor = Color.Red;
                        textBox.Text = "\nError!";
                        isDataCorrect = false;
                    }
                    else
                    {
                        nomOfCards.Add(nom);
                        char c = comb[i][colorPosition];
                        int ind = 0;
                        bool isColorExist = false;
                        for (int j = 0; j < maxLength; j++)
                        {
                            if (c == charColors[j])
                            {
                                ind = j;
                                isColorExist = true;
                                break;
                            }
                        }
                        if (!isColorExist)
                        {
                            textBox.ForeColor = Color.Red;
                            textBox.Text = "\nError!";
                            isDataCorrect = false;
                        }
                        else
                            colors.Add(codeOfColors[ind]);
                    }
                }
            }
        }
        public void findHighCard(ref int highCard, ref int n_highCard, int combLen, List<int> nomOfCards,  List<string> colors, string[] codeOfColors)
        {
            for (int i = 1; i < combLen; i++)
            {
                if (nomOfCards[i] > highCard)
                {
                    highCard = nomOfCards[i];
                    n_highCard = i;
                }
                else if (nomOfCards[i] == highCard)
                {
                    int ind1 = 0, ind2 = 0;
                    for (int j = 0; j < codeOfColors.Length; j++)
                    {
                        if (codeOfColors[j] == colors[i])
                            ind1 = j;
                        if (codeOfColors[j] == colors[n_highCard])
                            ind2 = j;
                    }
                    n_highCard = ind1 < ind2 ? i : n_highCard;
                    highCard = nomOfCards[n_highCard];
                }
            }
        }
        public void mainFunc(int combLen1, int combLen2)
        {
            Label[] labelsOnCards1 = { c11, c12, c13, c14, c15, c16, c17 };
            Label[] labelsOnCards2 = { c21, c22, c23, c24, c25, c26, c27 };
            Panel[] cardPanels1 = { card11, card12, card13, card14, card15, card16, card17 };
            Panel[] cardPanels2 = { card21, card22, card23, card24, card25, card26, card27 };
            List<int> nomOfCards1 = new List<int>();
            List<int> nomOfCards2 = new List<int>();
            List<string> colors1 = new List<string>();
            List<string> colors2 = new List<string>();
            string[] comb1 = new string[combLen1];
            string[] comb2 = new string[combLen2];
            char[] charColors = { 'R', 'O', 'Y', 'G', 'C', 'B', 'P' };
            string[] codeOfColors = { "#FF5B58", "#FFAC40", "#FFF650", "#8DFF70", "#97FFF3", "#7F8CFF", "#A978FF" };
            int highCard1, n_highCard1, highCard2, n_highCard2, numOfWinner, nominalOfWinner;
            string colorOfWinner;

            for (int i = 0; i < combLen1; i++)
                comb1[i] = textBox1.Lines[i + 1];
            for (int i = 0; i < combLen2; i++)
                comb2[i] = textBox2.Lines[i + 1];

            bool isDataCorrect = true;
            readData(ref isDataCorrect, combLen1, comb1, nomOfCards1, textBox1, charColors, colors1, codeOfColors);
            readData(ref isDataCorrect, combLen2, comb2, nomOfCards2, textBox2, charColors, colors2, codeOfColors);
            if (isDataCorrect == true) 
            {
                highCard1 = nomOfCards1[0];
                n_highCard1 = 0;
                findHighCard(ref highCard1, ref n_highCard1, combLen1, nomOfCards1, colors1, codeOfColors);
                highCard2 = nomOfCards2[0];
                n_highCard2 = 0;
                findHighCard(ref highCard2, ref n_highCard2, combLen2, nomOfCards2, colors2, codeOfColors);

                if (highCard1 > highCard2)
                {
                    numOfWinner = 1;
                    colorOfWinner = colors1[n_highCard1];
                    nominalOfWinner = nomOfCards1[n_highCard1];
                }
                else if (highCard1 == highCard2)
                {
                    int ind1 = 0, ind2 = 0;
                    for (int j = 0; j < codeOfColors.Length; j++)
                    {
                        if (codeOfColors[j] == colors1[n_highCard1])
                            ind1 = j;
                        if (codeOfColors[j] == colors2[n_highCard2])
                            ind2 = j;
                    }
                    if (ind1 < ind2)
                    {
                        numOfWinner = 1;
                        colorOfWinner = colors1[n_highCard1];
                        nominalOfWinner = nomOfCards1[n_highCard1];
                    }
                    else
                    {
                        numOfWinner = 2;
                        colorOfWinner = colors2[n_highCard2];
                        nominalOfWinner = nomOfCards2[n_highCard2];
                    }
                }
                else
                {
                    numOfWinner = 2;
                    colorOfWinner = colors2[n_highCard2];
                    nominalOfWinner = nomOfCards2[n_highCard2];
                }
                label3.Text = "Выиграла комбинация № " + numOfWinner;
                resCard.BackColor = ColorTranslator.FromHtml(colorOfWinner);
                resC.Text = Convert.ToString(nominalOfWinner);
                if (numOfWinner == 1)
                    textBox1.BackColor = Color.LightGreen;
                else
                    textBox2.BackColor = Color.LightGreen;
                for (int i = 0; i < combLen1; i++)
                {
                    labelsOnCards1[i].Text = Convert.ToString(nomOfCards1[i]);
                    cardPanels1[i].BackColor = ColorTranslator.FromHtml(colors1[i]);
                }
                for (int i = 0; i < combLen2; i++)
                {
                    labelsOnCards2[i].Text = Convert.ToString(nomOfCards2[i]);
                    cardPanels2[i].BackColor = ColorTranslator.FromHtml(colors2[i]);
                }
            }
            
        }

        private void do_btn_Click(object sender, EventArgs e)
        {
            int combLen1, combLen2;
            int num;
            bool isSizeInt = true;
            bool result1 = int.TryParse(textBox1.Lines[0], out num);
            bool result2 = int.TryParse(textBox2.Lines[0], out num);
            if (!result1)
            {
                textBox1.ForeColor = Color.Red;
                textBox1.Text = "\nError!";
                isSizeInt = false;
            }
            if (!result2)
            {
                textBox2.ForeColor = Color.Red;
                textBox2.Text = "\nError!";
                isSizeInt = false;
            }
            if (isSizeInt)
            {
                combLen1 = Convert.ToInt32(textBox1.Lines[0]);
                combLen2 = Convert.ToInt32(textBox2.Lines[0]);
                bool isSizeCorrect = true;
                if (combLen1 > 7 || combLen1 < 1)
                {
                    textBox1.ForeColor = Color.Red;
                    textBox1.Text = "\nIncorrect size!";
                    isSizeCorrect = false;
                }
                if (combLen2 > 7 || combLen2 < 1)
                {
                    textBox2.ForeColor = Color.Red;
                    textBox2.Text = "\nIncorrect size!";
                    isSizeCorrect = false;
                }
                if (isSizeCorrect)
                    mainFunc(combLen1, combLen2);
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            const int maxLenght = 7;
            string formColor = "#F0F0F0";
            Label[] labelsOnCards1 = { c11, c12, c13, c14, c15, c16, c17 };
            Label[] labelsOnCards2 = { c21, c22, c23, c24, c25, c26, c27 };
            Panel[] cardPanels1 = { card11, card12, card13, card14, card15, card16, card17 };
            Panel[] cardPanels2 = { card21, card22, card23, card24, card25, card26, card27 };
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.ForeColor = Color.Black;
            textBox2.ForeColor = Color.Black;
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            label3.Text = "Выиграла комбинация № ";
            resCard.BackColor = ColorTranslator.FromHtml(formColor);
            resC.Text = "";
            for (int i = 0; i < maxLenght; i++)
            {
                labelsOnCards1[i].Text = "";
                labelsOnCards2[i].Text = "";
                cardPanels1[i].BackColor = ColorTranslator.FromHtml(formColor);
                cardPanels2[i].BackColor = ColorTranslator.FromHtml(formColor);
            }
        }
    }
}

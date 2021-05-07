using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using EnumColors;

namespace Task1_GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public bool ReadData(int combLen, string[] comb, List<int> nomOfCards, TextBox textBox, List<string> colors)
        {
            bool isDataCorrect = true;
            const int nominalPosition = 0, colorPosition = 2;
            for (int i = 0; i < combLen; i++)
            {
                bool isCardNominalCorrect = int.TryParse(Convert.ToString(comb[i][nominalPosition]), out int enteredNominal);
                if (!isCardNominalCorrect)
                {
                    textBox.ForeColor = Color.Red;
                    textBox.Text = "\nInvalid value of card nominal!";
                    isDataCorrect = false;
                }
                else
                {
                    if (enteredNominal > 7 || enteredNominal < 1)
                    {
                        textBox.ForeColor = Color.Red;
                        textBox.Text = "\nCard nominal should be in the range [1, 7]!";
                        isDataCorrect = false;
                    }
                    else
                    {
                        nomOfCards.Add(enteredNominal);
                        char c = comb[i][colorPosition];
                        if (!Enum.TryParse(Convert.ToString(c), out Colors.SevenColors color))
                        {
                            textBox.Text = "Invalid value of color";
                            isDataCorrect = false;
                        }
                        colors.Add(Colors.GetDisplayName(color));
                    }
                }
            }
            return isDataCorrect;
        }
        public int GetIndexOfHigherCard(string color)
        {
            int ind;
            if (color == Colors.GetDisplayName(Colors.SevenColors.R))
            {
                ind = (int)Colors.SevenColors.R;
            }
            else if (color == Colors.GetDisplayName(Colors.SevenColors.O))
            {
                ind = (int)Colors.SevenColors.O;
            }
            else if (color == Colors.GetDisplayName(Colors.SevenColors.Y))
            {
                ind = (int)Colors.SevenColors.Y;
            }
            else if (color == Colors.GetDisplayName(Colors.SevenColors.G))
            {
                ind = (int)Colors.SevenColors.G;
            }
            else if (color == Colors.GetDisplayName(Colors.SevenColors.C))
            {
                ind = (int)Colors.SevenColors.C;
            }
            else if (color == Colors.GetDisplayName(Colors.SevenColors.B))
            {
                ind = (int)Colors.SevenColors.B;
            }
            else 
            {
                ind = (int)Colors.SevenColors.P;
            }
            return ind;
        }
        public int[] FindHighCard(int combLen, List<int> nomOfCards, List<string> colors)
        {
            int[] arr = new int[2];
            int highCard = nomOfCards[0], higherCardNumber = 0;
            for (int i = 1; i < combLen; i++)
            {
                if (nomOfCards[i] > highCard)
                {
                    highCard = nomOfCards[i];
                    higherCardNumber = i;
                }
                else if (nomOfCards[i] == highCard)
                {
                    int indexOfHigerCard1 = GetIndexOfHigherCard(colors[i]);
                    int indexOfHigerCard2 = GetIndexOfHigherCard(colors[higherCardNumber]);
                    higherCardNumber = indexOfHigerCard1 < indexOfHigerCard2 ? i : higherCardNumber;
                    highCard = nomOfCards[higherCardNumber];
                }
            }
            arr[0] = highCard;
            arr[1] = higherCardNumber;
            return arr;
        }
        public void MainFunc(int combLen1, int combLen2)
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
            int highCard1, higherCardNumber1, highCard2, higherCardNumber2, numOfWinner, nominalOfWinner;
            string colorOfWinner;

            for (int i = 0; i < combLen1; i++)
            {
                comb1[i] = textBox1.Lines[i + 1];
            }
            for (int i = 0; i < combLen2; i++)
            {
                comb2[i] = textBox2.Lines[i + 1];
            }

            bool isDataCorrect1, isDataCorrect2;
            isDataCorrect1 = ReadData(combLen1, comb1, nomOfCards1, textBox1, colors1);
            isDataCorrect2 = ReadData(combLen2, comb2, nomOfCards2, textBox2, colors2);
            if (isDataCorrect1 && isDataCorrect2)
            {
                int[] arr1 = FindHighCard(combLen1, nomOfCards1, colors1);
                int[] arr2 = FindHighCard(combLen2, nomOfCards2, colors2);
                highCard1 = arr1[0];
                higherCardNumber1 = arr1[1];
                highCard2 = arr2[0];
                higherCardNumber2 = arr2[1];

                if (highCard1 > highCard2)
                {
                    numOfWinner = 1;
                    colorOfWinner = colors1[higherCardNumber1];
                    nominalOfWinner = nomOfCards1[higherCardNumber1];
                }
                else if (highCard1 == highCard2)
                {
                    int indexOfHigerCard1 = GetIndexOfHigherCard(colors1[higherCardNumber1]);
                    int indexOfHigerCard2 = GetIndexOfHigherCard(colors2[higherCardNumber2]);
                    if (indexOfHigerCard1 < indexOfHigerCard2)
                    {
                        numOfWinner = 1;
                        colorOfWinner = colors1[higherCardNumber1];
                        nominalOfWinner = nomOfCards1[higherCardNumber1];
                    }
                    else
                    {
                        numOfWinner = 2;
                        colorOfWinner = colors2[higherCardNumber2];
                        nominalOfWinner = nomOfCards2[higherCardNumber2];
                    }
                }
                else
                {
                    numOfWinner = 2;
                    colorOfWinner = colors2[higherCardNumber2];
                    nominalOfWinner = nomOfCards2[higherCardNumber2];
                }
                label3.Text = "Выиграла комбинация № " + numOfWinner;
                resCard.BackColor = ColorTranslator.FromHtml(colorOfWinner);
                resC.Text = Convert.ToString(nominalOfWinner);
                if (numOfWinner == 1)
                {
                    textBox1.BackColor = Color.LightGreen;
                } 
                else
                {
                    textBox2.BackColor = Color.LightGreen;
                }
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

        private void DoBtnClick(object sender, EventArgs e)
        {
            bool isSizeInt = true;
            bool isCombLen1_Correct = int.TryParse(textBox1.Lines[0], out int combLen1);
            bool isCombLen2_Correct = int.TryParse(textBox2.Lines[0], out int combLen2);
            if (!isCombLen1_Correct)
            {
                textBox1.ForeColor = Color.Red;
                textBox1.Text = "\nInvalid value of count of cards!";
                isSizeInt = false;
            }
            if (!isCombLen2_Correct)
            {
                textBox2.ForeColor = Color.Red;
                textBox2.Text = "\nInvalid value of count of cards!";
                isSizeInt = false;
            }
            if (isSizeInt)
            {
                bool isSizeCorrect = true;
                if (combLen1 > 7 || combLen1 < 1)
                {
                    textBox1.ForeColor = Color.Red;
                    textBox1.Text = "\nCount of cards should be in the range [1, 7]!";
                    isSizeCorrect = false;
                }
                if (combLen2 > 7 || combLen2 < 1)
                {
                    textBox2.ForeColor = Color.Red;
                    textBox2.Text = "\nCount of cards should be in the range [1, 7]!";
                    isSizeCorrect = false;
                }
                if (isSizeCorrect)
                {
                    MainFunc(combLen1, combLen2);
                }
            }
        }

        private void ClearBtnClick(object sender, EventArgs e)
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


using EnumColors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace Task1_GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        void CreateCardCombination(int combLen, List<Card> cards, TextBox textBox)
        {
            for (int i = 0; i < combLen; i++)
            {
                Card card = new Card(textBox.Lines[i + 1]);
                cards.Add(card);
            }
        }
        
        public void MainFunc(int combLen1, int combLen2)
        { 
            List<Card> cards1 = new List<Card>();
            List<Card> cards2 = new List<Card>();
            Card higherCard1, higherCard2;

            CreateCardCombination(combLen1, cards1, textBox1);
            CreateCardCombination(combLen2, cards2, textBox2);

            if(Service.AreAnyIdenticalCards(cards1, cards2))
            {
                throw new Exception("There can be no identical cards");
            }

            cards1.Sort();
            cards2.Sort();

            higherCard1 = cards1.Last();
            higherCard2 = cards2.Last();

            Card winnerCard = Service.FindWinCard(higherCard1, higherCard2);
            int numOfWinnerCombination = Service.GetNumOfWinnerCombination(higherCard1, higherCard2);

            label3.Text = "Выиграла комбинация № " + numOfWinnerCombination;
            resCard.BackColor = ColorTranslator.FromHtml(Colors.GetDisplayName(winnerCard.Color));
            resC.Text = Convert.ToString(winnerCard.Nominal);

            if (numOfWinnerCombination == 1)
            {
                textBox1.BackColor = Color.LightGreen;
            }
            else
            {
                textBox2.BackColor = Color.LightGreen;
            }

            Label[] labelsOnCards1 = { c11, c12, c13, c14, c15, c16, c17 };
            Label[] labelsOnCards2 = { c21, c22, c23, c24, c25, c26, c27 };
            Panel[] cardPanels1 = { card11, card12, card13, card14, card15, card16, card17 };
            Panel[] cardPanels2 = { card21, card22, card23, card24, card25, card26, card27 };

            for (int i = 0; i < combLen1; i++)
            {
                labelsOnCards1[i].Text = Convert.ToString(cards1[i].Nominal);
                cardPanels1[i].BackColor = ColorTranslator.FromHtml(Colors.GetDisplayName(cards1[i].Color));
            }
            for (int i = 0; i < combLen2; i++)
            {
                labelsOnCards2[i].Text = Convert.ToString(cards2[i].Nominal);
                cardPanels2[i].BackColor = ColorTranslator.FromHtml(Colors.GetDisplayName(cards2[i].Color));
            }
        }

        private void DoBtnClick(object sender, EventArgs e)
        {
            bool isSizeInt = true;
            errorMessageLabel.Text = "";

            try
            {
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
            catch(Exception error)
            {
                errorMessageLabel.Text = "Error: " + error.Message;
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


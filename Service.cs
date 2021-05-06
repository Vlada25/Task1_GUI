using System;
using System.Collections.Generic;
using EnumColors;

namespace Task1_GUI
{
    internal class Service
    {
        public struct HigherCard
        {
            public static int nominal_of_HigherCard;
            public static int number_of_HigherCard;
        }
        public struct WinCombination
        {
            public static int numOfWinner;
            public static Card winnerCard;
        }
        public static string ErrorMessage { get; set; }
        public static int CardNominal { get; set; }
        public static string CardColor { get; set; }
        public static bool CheckEnteredCombination(string combination)
        {
            bool isDataCorrect = true;
            const int nominalPosition = 0, colorPosition = 2;
            bool isCardNominalCorrect = int.TryParse(Convert.ToString(combination[nominalPosition]), out int enteredNominal);
            if (!isCardNominalCorrect)
            {
                ErrorMessage = "\nInvalid value of card nominal!";
                isDataCorrect = false;
            }
            else
            {
                if (enteredNominal > 7 || enteredNominal < 1)
                {
                    ErrorMessage = "\nCard nominal should be in the range [1, 7]!";
                    isDataCorrect = false;
                }
                else
                {
                    if (!Enum.TryParse(Convert.ToString(combination[colorPosition]), out Colors.SevenColors color))
                    {
                        ErrorMessage = "Invalid value of color";
                        isDataCorrect = false;
                    }
                    CardNominal = enteredNominal;
                    CardColor = Colors.GetDisplayName(color);
                }
            }
            return isDataCorrect;
        }
        public static bool AreAnyIdenticalCards(List<Card> cards1, List<Card> cards2)
        {
            for (int i = 0; i < cards1.Count; i++)
            {
                for (int j = 0; j < cards2.Count; j++)
                {
                    if (cards1[i].Equals(cards2[j]))
                    {
                        ErrorMessage = "There can be no identical cards";
                        return true;
                    }
                }
            }
            return false;
        }
        public static int GetIndexOfHigherCard(string color)
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
        public static void FindHighCard(int combLen, List<Card> cards)
        {
            int higherCardNominal = cards[0].Nominal, higherCardNumber = 0;
            for (int i = 1; i < combLen; i++)
            {
                if (cards[i].Nominal > higherCardNominal)
                {
                    higherCardNominal = cards[i].Nominal;
                    higherCardNumber = i;
                }
                else if (cards[i].Nominal == higherCardNominal)
                {
                    int indexOfHigerCard1 = GetIndexOfHigherCard(cards[i].Color);
                    int indexOfHigerCard2 = GetIndexOfHigherCard(cards[higherCardNumber].Color);
                    higherCardNumber = indexOfHigerCard1 < indexOfHigerCard2 ? i : higherCardNumber;
                    higherCardNominal = cards[higherCardNumber].Nominal;
                }
            }
            HigherCard.nominal_of_HigherCard = higherCardNominal;
            HigherCard.number_of_HigherCard = higherCardNumber;
        }

        public static void FindWinCombination(int highCard1, int highCard2, List<Card> cards1, List<Card> cards2, int higherCardNumber1, int higherCardNumber2)
        {
            if (highCard1 > highCard2)
            {
                WinCombination.numOfWinner = 1;
                WinCombination.winnerCard = cards1[higherCardNumber1];
            }
            else if (highCard1 == highCard2)
            {
                int indexOfHigerCard1 = Service.GetIndexOfHigherCard(cards1[higherCardNumber1].Color);
                int indexOfHigerCard2 = Service.GetIndexOfHigherCard(cards2[higherCardNumber2].Color);
                if (indexOfHigerCard1 < indexOfHigerCard2)
                {
                    WinCombination.numOfWinner = 1;
                    WinCombination.winnerCard = cards1[higherCardNumber1];
                }
                else
                {
                    WinCombination.numOfWinner = 2;
                    WinCombination.winnerCard = cards2[higherCardNumber2];
                }
            }
            else
            {
                WinCombination.numOfWinner = 2;
                WinCombination.winnerCard = cards2[higherCardNumber2];
            }
        }
    }
}
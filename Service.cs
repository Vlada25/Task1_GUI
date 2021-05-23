using System.Collections.Generic;

namespace Task1_GUI
{
    internal class Service
    {
        public struct WinCombination
        {
            public static int NumOfWinner;
            public static Card WinnerCard;
        }
        public static string ErrorMessage { get; set; }

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

        public static void FindWinCombination(Card higherCard1, Card higherCard2, List<Card> cards1, List<Card> cards2)
        {
            int flag = higherCard1.CompareTo(higherCard2);
            if (flag == 1)
            {
                WinCombination.NumOfWinner = 1;
                WinCombination.WinnerCard = cards1[cards1.Count - 1];
            }
            else
            {
                WinCombination.NumOfWinner = 2;
                WinCombination.WinnerCard = cards2[cards1.Count - 1];
            }
        }
    }
}
using System;
using System.Collections.Generic;

namespace Task1_GUI
{
    internal class Service
    {
        public static string ErrorMessage { get; set; }

        public static void AreAnyIdenticalCards(List<Card> cards1, List<Card> cards2)
        {
            for (int i = 0; i < cards1.Count; i++)
            {
                for (int j = 0; j < cards2.Count; j++)
                {
                    if (cards1[i].Equals(cards2[j]))
                    {
                        throw new Exception("There can be no identical cards");
                    }
                }
            }
        }

        public static Card FindWinCombination(Card higherCard1, Card higherCard2)
        {
            Card card;
            int flag = higherCard1.CompareTo(higherCard2);
            if (flag == 1)
            {
                card = higherCard1;
                Card.NumOfWinner = 1;
            }
            else
            {
                card = higherCard2;
                Card.NumOfWinner = 2;
            }
            return card;
        }
    }
}
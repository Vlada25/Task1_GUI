using EnumColors;
using System;

namespace Task1_GUI
{
    internal class Card : IComparable
    {
        private int setterNominal;
        private Colors.SevenColors setterColor;
        public int Nominal { get; }
        public Colors.SevenColors Color { get; }
        public static int NumOfWinner { get; set; }
        public Card(string combination)
        {
            CheckEnteredCombination(combination);
            Nominal = setterNominal;
            Color = setterColor;
        }
        public bool Equals(Card card)
        {
            return (Nominal == card.Nominal && Color == card.Color);
        }
        public override string ToString()
        {
            return (Nominal + " " + Color);
        }
        private void CheckEnteredCombination(string combination)
        {
            const int nominalPosition = 0, colorPosition = 2;
            int enteredNominal = Convert.ToInt32(combination[nominalPosition]) - 48;
            if (enteredNominal > 7 || enteredNominal < 1)
            {
                throw new Exception("Card nominal should be in the range [1, 7]!");
            }
            else
            {
                if (!Enum.TryParse(Convert.ToString(combination[colorPosition]), out Colors.SevenColors color))
                {
                    throw new Exception("One of the colors does not exist");
                }
                setterNominal = enteredNominal;
                setterColor = color;
            }
        }
        public int CompareTo(object obj)
        {
            if (obj is Card card)
            {
                if (Nominal < card.Nominal)
                {
                    return -1;
                }
                else if (Nominal > card.Nominal)
                {
                    return 1;
                }
                else
                {
                    return Color.CompareTo(card.Color);
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
using EnumColors;
using System;
using static EnumColors.Colors;

namespace Task1_GUI
{
    class Card : IComparable
    {
        public int Nominal { get; }
        public SevenColors Color { get; }
        public static int NumOfWinner { get; set; }
        public Card(string combination)
        {
            const int nominalPosition = 0,
                colorPosition = 2,
                ASCIIzeroPosition = 48;
            Nominal = SetNominal(Convert.ToInt32(combination[nominalPosition]) - ASCIIzeroPosition);
            Color = SetColor(Convert.ToString(combination[colorPosition]));
        }
        public bool Equals(Card card)
        {
            return (Nominal == card.Nominal && Color == card.Color);
        }
        public override string ToString()
        {
            return (Nominal + " " + Color);
        }
        private int SetNominal(int nominal)
        {
            const int maxLenght = 7,
                minLength = 1;
            
            if (nominal > maxLenght || nominal < minLength)
            {
                throw new Exception("Card nominal should be in the range [1, 7]!");
            }
            return nominal;
        }
        private SevenColors SetColor(string strColor)
        {
            if (!Enum.TryParse(strColor, out SevenColors color))
            {
                throw new Exception("One of the colors does not exist");
            }
            return color;
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
using EnumColors;
using System;

namespace Task1_GUI
{
    internal class Card : IComparable
    {
        public int Nominal { get; set; }
        public Colors.SevenColors Color { get; set; }
        public static bool IsCardCorrect { get; set; }
        public Card() { }
        public Card(string combination)
        {
            IsCardCorrect = CheckEnteredCombination(combination);
        }
        public bool Equals(Card card)
        {
            return (Nominal == card.Nominal && Color == card.Color);
        }
        public override string ToString()
        {
            return (Nominal + " " + Color);
        }
        private bool CheckEnteredCombination(string combination)
        {
            bool isDataCorrect = true;
            const int nominalPosition = 0, colorPosition = 2;
            bool isCardNominalCorrect = int.TryParse(Convert.ToString(combination[nominalPosition]), out int enteredNominal);
            if (!isCardNominalCorrect)
            {
                Service.ErrorMessage = "\nInvalid value of card nominal!";
                isDataCorrect = false;
            }
            else
            {
                if (enteredNominal > 7 || enteredNominal < 1)
                {
                    Service.ErrorMessage = "\nCard nominal should be in the range [1, 7]!";
                    isDataCorrect = false;
                }
                else
                {
                    if (!Enum.TryParse(Convert.ToString(combination[colorPosition]), out Colors.SevenColors color))
                    {
                        Service.ErrorMessage = "Invalid value of color";
                        isDataCorrect = false;
                    }
                    Nominal = enteredNominal;
                    Color = color;
                }
            }
            return isDataCorrect;
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
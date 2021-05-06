namespace Task1_GUI
{
    internal class Card
    {
        public int Nominal { get; set; }
        public string Color { get; set; }
        public static bool IsCardCorrect { get; set; }
        public Card() { }
        public Card(string combination)
        {
            IsCardCorrect = Service.CheckEnteredCombination(combination);
            if (IsCardCorrect)
            {
                Nominal = Service.CardNominal;
                Color = Service.CardColor;
            }
        }
        public bool Equals(Card card)
        {
            return (this.Nominal == card.Nominal && this.Color == card.Color);
        }
        public override string ToString()
        {
            return (Nominal + " " + Color);
        }
    }
}
namespace MilitaryPuzzle.App.Model
{
    public class Card
    {
        public int CardId { get; set; }
        public CardSideModel Top { get; set; }
        public CardSideModel Right { get; set; }
        public CardSideModel Bottom { get; set; }
        public CardSideModel Left { get; set; }
    }
}

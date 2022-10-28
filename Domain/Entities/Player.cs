namespace Deck_of_Cards.Domain.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Card[] Cards { get; set; } = new Card[5];
        public int? Points { get; set; }

        public Player(string name)
        {
            Name = name;
        }

    }
}
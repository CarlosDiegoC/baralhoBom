using Newtonsoft.Json;

namespace Deck_of_Cards.Domain.Entities
{
    public sealed class Player
    {
        public int Id { get; private set; }
        public Card[] Cards { get; set; }
        public int Points { get; private set; }

        public Player()
        {
            Cards = DrawFiveCardsFromANewDeck().Result;
            Points = SumPlayerPoints();
        }

        public async Task<Card[]> DrawFiveCardsFromANewDeck()
        {          
            Cards = new Card[5];
            HttpClient client = new HttpClient();
            var newCardsRequisition = await client.GetAsync($"https://deckofcardsapi.com/api/deck/new/draw/?count=5");
            var newCardsResponse = await newCardsRequisition.Content.ReadAsStringAsync();
            var newCards = JsonConvert.DeserializeObject<DrawCardModel>(newCardsResponse);
            return newCards.Cards;
        }

        private int SumPlayerPoints()
        {
            int PlayerPoints = 0;
            foreach(Card card in Cards)
            {
                PlayerPoints += ReturnCardValue(card.Value);
            }
            return PlayerPoints;
        }

        private int ReturnCardValue(string valor)
        {
           if(valor == "ACE") return 1;
           if(valor == "JACK") return 11;
           if(valor == "QUEEN") return 12;
           if(valor == "KING") return 13;
           return Int32.Parse(valor);
        }
    }
}
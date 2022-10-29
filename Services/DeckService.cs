using Deck_of_Cards.Domain.Entities;
using Newtonsoft.Json;

namespace Deck_of_Cards.Services
{
    public class DeckService
    {
        public async Task<Deck> CreateDeck()
        {
            HttpClient client = new HttpClient();
            var newDeckRequisition = await client.GetAsync("https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1");
            var newDeckResponse = await newDeckRequisition.Content.ReadAsStringAsync();
            var newDeck = JsonConvert.DeserializeObject<Deck>(newDeckResponse);
            return newDeck;
        }
    }
}
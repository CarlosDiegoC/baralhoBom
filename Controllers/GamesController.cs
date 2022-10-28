using Deck_of_Cards.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Deck_of_Cards.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Game>> StartNewMatch()
        {
            HttpClient client = new HttpClient();
            var newDeckRequisition = await client.GetAsync("https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1");
            var newDeckResponse = await newDeckRequisition.Content.ReadAsStringAsync();
            var newDeck = JsonConvert.DeserializeObject<Deck>(newDeckResponse);

            var newCardsRequisition = await client.GetAsync($"https://deckofcardsapi.com/api/deck/{newDeck!.deck_id}/draw/?count=20");
            var newCardsResponse = await newCardsRequisition.Content.ReadAsStringAsync();
            var newCards = JsonConvert.DeserializeObject<DrawCardModel>(newCardsResponse);
            
            Player Player01 = new Player("Player01");
            Player Player02 = new Player("Player02");
            Player Player03 = new Player("Player03");
            Player Player04 = new Player("Player04");
            Player01.Cards = newCards.cards[0..4];
            Player02.Cards = newCards.cards[5..9];
            Player03.Cards = newCards.cards[10..14];
            Player04.Cards = newCards.cards[15..19];

            int? Player01Points = 0;
            int? Player02Points = 0;
            int? Player03Points = 0;
            int? Player04Points = 0;

            foreach(Card card in Player01.Cards)
            {
                Player01Points += retornaValor(card.Value);
            }

            foreach(Card card in Player02.Cards)
            {
                Player02Points += retornaValor(card.Value);
            }

            foreach(Card card in Player03.Cards)
            {
                Player03Points += retornaValor(card.Value);
            }

            foreach(Card card in Player04.Cards)
            {
                Player04Points += retornaValor(card.Value);
            }

            Player01.Points = Player01Points;
            Player02.Points = Player02Points;
            Player03.Points = Player03Points;
            Player04.Points = Player04Points;

            List<Player> listaDePlayers = new List<Player> {Player01, Player02, Player03, Player04};
            Player vencedor = listaDePlayers.OrderByDescending(player => player.Points).ToList()[0];
            Game game = new Game();
            game.Id = 1;
            game.DeckId = newDeck.deck_id;
            game.Players = listaDePlayers;
            game.Winner = vencedor;
            
            return Ok(game);
        }

        public static int? retornaValor(string valor)
        {
           if(valor == "ACE") return 1;
           if(valor == "JACK") return 11;
           if(valor == "QUEEN") return 12;
           if(valor == "KING") return 13;
           int outInt;
           return int.TryParse(valor, out outInt) ? outInt : (int?)null;
        }
    }
}
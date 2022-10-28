using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deck_of_Cards.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Deck_of_Cards.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DecksController : ControllerBase
    {
        HttpClient client = new HttpClient();

        [HttpPost]
        public async Task<ActionResult> StartNewMatch()
        {
            
            var newDeckRequisition = await client.GetAsync("https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1");
            var newDeckResponse = await newDeckRequisition.Content.ReadAsStringAsync();
            var newDeck = JsonConvert.DeserializeObject<Deck>(newDeckResponse);
            return Ok(newDeck);
        }

        [HttpGet]
        public async Task<ActionResult> DrawCards()
        {
            var newCardsRequisition = await client.GetAsync($"https://deckofcardsapi.com/api/deck/new/draw/?count=5");
            var newCardsResponse = await newCardsRequisition.Content.ReadAsStringAsync();
            var newCards = JsonConvert.DeserializeObject<DrawCardModel>(newCardsResponse);

            return Ok(newCards);
        }
    }
}
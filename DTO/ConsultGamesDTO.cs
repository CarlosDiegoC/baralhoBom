using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deck_of_Cards.Domain.Entities;

namespace Deck_of_Cards.DTO
{
    public class ConsultGamesDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Player Winner { get; set; }
    }
}
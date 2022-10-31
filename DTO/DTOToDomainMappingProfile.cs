using AutoMapper;
using Deck_of_Cards.Domain.Entities;

namespace Deck_of_Cards.DTO
{
    public class DTOToDomainMappingProfile : Profile
    {
        public DTOToDomainMappingProfile()
        {
            CreateMap<CreateANewPlayer, Player>().ReverseMap();
            CreateMap<CreateANewGame, Game>().ReverseMap();
            CreateMap<ConsultGamesDTO, Game>().ReverseMap();
        }
    }
}
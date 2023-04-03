using AutoMapper;
using MelVincentAnonuevo_COMP306Project.DTOs;
using MelVincentAnonuevo_COMP306Project.Models;

namespace MelVincentAnonuevo_COMP306Project.Mappings
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<GameInfo, GameCommentsDto>();
            CreateMap<GameInfo, GameInfoDto>();
            CreateMap<GameInfoWithoutCommentsDto, GameInfo>();
            CreateMap<GameInfo, GameInfoWithoutCommentsDto>();
            CreateMap<GameCommentsDto, GameComment>();
            CreateMap<GameComment, GameCommentsDto>();
            CreateMap<GameCommentUpdateDto, GameComment>();
            CreateMap<GameComment, GameCommentUpdateDto>();
            CreateMap<GameRatingDto, GameRating>();
            CreateMap<GameRating, GameRatingDto>();
            CreateMap<GameRatingUpdateDto, GameRating>();


        }
    }
}

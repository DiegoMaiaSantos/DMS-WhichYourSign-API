using AutoMapper;
using DMS_WhichYourSign_API.Src.Domain.DTOs;
using DMS_WhichYourSign_API.Src.Infra.Data.Entities;

namespace DMS_WhichYourSign_API.Src.Domain.Mappings
{
    public class DTOToEntityMapping : Profile
    {
        public DTOToEntityMapping()
        {
            CreateMap<WhichYourSignResponseDTO, WhichYourSign>();
        }
    }
}

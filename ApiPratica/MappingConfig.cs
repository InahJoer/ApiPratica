using ApiPratica.Models;
using ApiPratica.Models.Dto;
using ApiPratica.Repository;
using AutoMapper;

namespace ApiPratica
{
    public class MappingConfig : Profile 
    {
        public MappingConfig() 
        {
            CreateMap<Mascotas, MascotasDto>();
            CreateMap<MascotasDto, Mascotas>();

            CreateMap<Mascotas, MascotasCreateDto>().ReverseMap();
            CreateMap<Mascotas, MascotasUpdateDto>().ReverseMap();
        }  
    }
}

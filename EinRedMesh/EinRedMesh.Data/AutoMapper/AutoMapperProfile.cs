using AutoMapper;
using Ein.Dtos;
using Ein.Entidades;

namespace EinRedMesh.Data.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            
            CreateMap<GeneracionSetDto, GeneracionEntity>()
                .ForMember(campo => campo.EstaActivo, asignar => asignar.MapFrom(dto => true));

            CreateMap<GeneracionEntity, GeneracionGetDto>();


            
            CreateMap<GrupoSetDto, GrupoEntity>()
                .ForMember(campo => campo.EstaActivo, asignar => asignar.MapFrom(dto => true));

            CreateMap<GrupoEntity, GrupoGetDto>()
                .ForMember(campo => campo.NombreGeneracion, asignar => asignar.MapFrom(valor => valor.Generacion.Nombre));
        }
    }
}

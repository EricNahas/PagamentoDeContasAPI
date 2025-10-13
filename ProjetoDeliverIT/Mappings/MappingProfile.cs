using AutoMapper;
using ProjetoDeliverIT.DTOs;
using ProjetoDeliverIT.Models;

namespace ProjetoDeliverIT.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Conta, ContaDTO>().ReverseMap();
        }
    }
}

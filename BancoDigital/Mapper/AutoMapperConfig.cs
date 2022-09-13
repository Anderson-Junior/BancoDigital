using AutoMapper;
using BancoDigital.Entities;
using BancoDigital.Models;

namespace BancoDigital.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Conta, AddContaInputModel>().ReverseMap();
            CreateMap<Conta, ContaViewModel>().ReverseMap();
            CreateMap<Conta, DepositarInputModel>().ReverseMap();
        }
    }
}

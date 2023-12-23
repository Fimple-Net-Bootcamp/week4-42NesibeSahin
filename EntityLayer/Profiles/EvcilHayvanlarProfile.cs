using AutoMapper;
using EntityLayer.DTOs;
using EntityLayer.Entities;

namespace EntityLayer.Profiles
{
    public class EvcilHayvanlarProfile:Profile
    {
        public EvcilHayvanlarProfile()
        {
            CreateMap<EvcilHayvanlar, EvcilHayvanDTO>();
            CreateMap<EvcilHayvanEkleDTO, EvcilHayvanlar>();
            CreateMap<EvcilHayvanDTO, EvcilHayvanlar>();

        }

    }
}

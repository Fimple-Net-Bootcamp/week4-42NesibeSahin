using AutoMapper;
using EntityLayer.DTOs;
using EntityLayer.Entities;

namespace EntityLayer.Profiles
{
    public class BesinlerProfile:Profile
    {
        public BesinlerProfile()
        {
            CreateMap<Besinler, BesinlerDTO>();
            CreateMap<BesinlerDTO,Besinler>();
            CreateMap<BesinlerEkleDTO, Besinler>();
            CreateMap<Beslenme, LogBeslenme>();

        }
    }
}

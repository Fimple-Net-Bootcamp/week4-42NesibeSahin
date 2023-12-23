using AutoMapper;
using EntityLayer.DTOs;
using EntityLayer.Entities;

namespace EntityLayer.Profiles
{
    public class EgitimlerProfile:Profile
    {
        public EgitimlerProfile()
        {
            CreateMap<Egitimler, EgitimlerDTO>().ReverseMap();
            CreateMap<EgitimlerEkleDTO, Egitimler>().ReverseMap();

        }
    }
}

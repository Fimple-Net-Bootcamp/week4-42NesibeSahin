using AutoMapper;
using EntityLayer.DTOs;
using EntityLayer.Entities;

namespace EntityLayer.Profiles
{
    public class SosyalEtkilesimlerProfile:Profile
    {
        public SosyalEtkilesimlerProfile()
        {
            CreateMap<SosyalEtkilesimler, SosyalEtkilesimlerDTO>().ReverseMap();
            CreateMap<SosyalEtkilesimlerEkleDTO, SosyalEtkilesimler>().ReverseMap();
        }
    }
}

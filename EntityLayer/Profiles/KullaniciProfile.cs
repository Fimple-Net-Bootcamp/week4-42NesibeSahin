using AutoMapper;
using EntityLayer.DTOs;
using EntityLayer.Entities;

namespace EntityLayer.Profiles
{
    public class KullaniciProfile : Profile
    {
        public KullaniciProfile()
        {
            CreateMap<Kullanici, KullaniciDTO>();
            CreateMap<KullaniciEkleDTO, Kullanici>();    
        }
    }
}

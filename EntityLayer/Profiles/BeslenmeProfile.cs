using AutoMapper;
using EntityLayer.DTOs;
using EntityLayer.Entities;

namespace EntityLayer.Profiles
{
	public class BeslenmeProfile:Profile
	{
		public BeslenmeProfile()
		{
			CreateMap<Beslenme, BeslenmeDTO>().ReverseMap();
			CreateMap<BeslenmeEkleDTO, Beslenme>().ReverseMap();
			CreateMap<LogBeslenme, LogBeslenmeDTO>().ReverseMap();
		}
	}
}

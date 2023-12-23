using AutoMapper;
using EntityLayer.DTOs;
using EntityLayer.Entities;

namespace EntityLayer.Profiles
{
    public class AktivitelerProfile:Profile
    {
        public AktivitelerProfile()
        {
            CreateMap<Aktiviteler, AktivitelerDTO>();
            CreateMap<AktivitelerEkleDTO, Aktiviteler>();
            CreateMap<Aktiviteler, AktivitelerEkleDTO>();
            CreateMap<AktivitelerDTO, Aktiviteler>();
            CreateMap<Aktiviteler, LogAktivite>();
			CreateMap<LogAktivite, logAktivitelerDTO>();
		}

    }
}

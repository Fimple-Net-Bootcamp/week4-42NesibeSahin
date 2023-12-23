using AutoMapper;
using EntityLayer.DTOs;
using EntityLayer.Entities;

namespace EntityLayer.Profiles
{
    public class SaglikDurumlariProfile : Profile
    {
        public SaglikDurumlariProfile()
        {
            CreateMap<SaglikDurumlari, SaglikDurumlariDTO>();
            CreateMap<SaglikDurumlariDTO, SaglikDurumlari>();
            CreateMap<SaglikDurumlari, LogSaglik>();
			CreateMap<LogSaglik, LogSaglikDurumlariDTO>();

		}
    }
}

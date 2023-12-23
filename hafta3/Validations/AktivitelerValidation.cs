using FluentValidation;
using EntityLayer.DTOs;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Data;

namespace hafta3.Validations
{
	public class AktivitelerValidation: AbstractValidator<AktivitelerEkleDTO>
	{
		
		public AktivitelerValidation()
        {
			
			RuleFor(x => x.Adi)
				//.Cascade(CascadeMode.StopOnFirstFailure)
				.NotEmpty().WithMessage("Boş geçilemez")
				.MinimumLength(3).WithMessage("3 ten küçük olamaz")
				.MaximumLength(50).WithMessage("50 den büyük olamaz")
				 .Matches(@"^[a-zA-ZçÇğĞıİöÖşŞüÜ]+$").WithMessage("Ad sadece Türkçe ve İngilizce alfabetik karakterler içermelidir.");

		
			RuleFor(x => x.EvcilHayvanID)
				.NotEmpty().WithMessage("Boş geçilemez")
				.GreaterThanOrEqualTo(1).WithMessage("Evcil Hayvan ID en az 1 olmalıdır.")
				.LessThanOrEqualTo(20).WithMessage("Evcil Hayvan ID en fazla 20  olabilir.");
		}
       
	}
}

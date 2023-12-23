using FluentValidation;
using EntityLayer.DTOs;
namespace hafta3.Validations
{
	public class BesinlerValidation : AbstractValidator<BesinlerEkleDTO>
	{
        public BesinlerValidation()
        {
			RuleFor(x => x.Adi)
			//.Cascade(CascadeMode.StopOnFirstFailure)
			.NotEmpty().WithMessage("Boş geçilemez")
			.MinimumLength(3).WithMessage("3 ten küçük olamaz")
			.MaximumLength(50).WithMessage("50 den büyük olamaz")
			 .Matches(@"^[a-zA-ZçÇğĞıİöÖşŞüÜ]+$").WithMessage("Ad sadece Türkçe ve İngilizce alfabetik karakterler içermelidir.");


		}
	}
}

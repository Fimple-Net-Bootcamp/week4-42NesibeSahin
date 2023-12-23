using FluentValidation;
using EntityLayer.DTOs;

namespace hafta3.Validations
{
	public class KullaniciValidation : AbstractValidator<KullaniciEkleDTO>
	{
		public KullaniciValidation()
		{
			RuleFor(x => x.Adi)
			.NotEmpty().WithMessage("Adı boş olamaz.")
			.MaximumLength(50).WithMessage("Adı en fazla 50 karakter olabilir.")
			.Matches(@"^[a-zA-ZğüşöçİĞÜŞÖÇ]+$").WithMessage("Ad sadece harf içermelidir.");

			RuleFor(x => x.Soyadi)
				.NotEmpty().WithMessage("Soyadı boş olamaz.")
				.MaximumLength(50).WithMessage("Soyadı en fazla 50 karakter olabilir.")
				.Matches(@"^[a-zA-ZğüşöçİĞÜŞÖÇ]+$").WithMessage("Soyad sadece harf içermelidir.");

			RuleFor(x => x.TC)
				.NotEmpty().WithMessage("TC Kimlik Numarası boş olamaz.")
				.Length(11).WithMessage("TC Kimlik Numarası tam olarak 11 karakter olmalıdır.")
				.Matches(@"^[1-9][0-9]*$").WithMessage("TC Kimlik Numarası sadece rakamlardan oluşmalı ve 0 ile başlamamalıdır.");
		}
	}

}

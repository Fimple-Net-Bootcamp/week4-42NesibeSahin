using FluentValidation;
using EntityLayer.DTOs;

namespace hafta3.Validations
{
	public class EvcilHayvanValidation : AbstractValidator<EvcilHayvanEkleDTO>
	{
        public EvcilHayvanValidation()
        {
			RuleFor(x => x.Isim)
						.NotEmpty().WithMessage("İsim boş olamaz.")
						.MaximumLength(100).WithMessage("İsim en fazla 100 karakter olabilir.");

			RuleFor(x => x.Kodu)
				.NotEmpty().WithMessage("Kodu boş olamaz.")
				.GreaterThanOrEqualTo(1).WithMessage("Kodu 0'dan büyük olmalıdır.");

			RuleFor(x => x.Tur)
				.NotEmpty().WithMessage("Tur boş olamaz.")
				.MaximumLength(50).WithMessage("Tur en fazla 50 karakter olabilir.");

			RuleFor(x => x.KullaniciID)
				.NotEmpty().WithMessage("Kullanıcı ID boş olamaz.")
				.GreaterThanOrEqualTo(1).WithMessage("Kullanıcı ID 0'dan büyük olmalıdır.");
		}
    }
}

using FluentValidation;
using EntityLayer.DTOs;

namespace hafta3.Validations
{
	public class BeslenmeValidation : AbstractValidator<BeslenmeEkleDTO>
	{
        public BeslenmeValidation()
        {
			RuleFor(x => x.BesinlerID)
				.NotEmpty().WithMessage("Boş geçilemez")
				.GreaterThanOrEqualTo(1).WithMessage("Besin ID en az 1 olmalıdır.")
				.LessThanOrEqualTo(20).WithMessage("Besin ID en fazla 20  olabilir.");
		}
    }
}

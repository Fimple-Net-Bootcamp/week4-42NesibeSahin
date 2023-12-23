using FluentValidation;
using EntityLayer.DTOs;

namespace hafta3.Validations
{
	public class SosyalEtkilesimlerValidation : AbstractValidator<SosyalEtkilesimlerEkleDTO>
	{
        public SosyalEtkilesimlerValidation()
        {
			RuleFor(x => x.EtkinlikID)
			.NotEmpty().WithMessage("Etkinlik ID boş olamaz.")
			.GreaterThanOrEqualTo(1).WithMessage("Etkinlik ID 0'dan büyük olmalıdır.");

			RuleFor(x => x.EvcilHayvanID)
				.NotEmpty().WithMessage("Evcil Hayvan ID boş olamaz.")
				.GreaterThanOrEqualTo(1).WithMessage("Evcil Hayvan ID 0'dan büyük olmalıdır.");
		}
    }
}

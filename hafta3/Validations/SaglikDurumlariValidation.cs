using FluentValidation;
using EntityLayer.DTOs;

namespace hafta3.Validations
{
	public class SaglikDurumlariValidation : AbstractValidator<SaglikDurumlariCevapDTO>
	{
        public SaglikDurumlariValidation()
        {
			RuleFor(x => x.DurumAdi)
			.NotEmpty().WithMessage("Durum adı boş olamaz.")
			.MaximumLength(100).WithMessage("Durum adı en fazla 100 karakter olabilir.");


			RuleFor(x => x.EvcilHayvanID)
				.NotEmpty().WithMessage("Evcil Hayvan ID boş olamaz.")
				.GreaterThanOrEqualTo(1).WithMessage("Evcil Hayvan ID geçersiz.");

			RuleFor(x => x.Tarih)
				.NotEmpty().WithMessage("Tarih boş olamaz.")
				.LessThanOrEqualTo(DateTime.Now).WithMessage("Tarih gelecekteki bir tarih olamaz.");
		}
    }
}

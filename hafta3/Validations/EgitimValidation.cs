using EntityLayer.DTOs;
using FluentValidation;


namespace hafta3.Validations
{
	public class EgitimValidation : AbstractValidator<EgitimlerEkleDTO>
	{
        public EgitimValidation()
        {
			RuleFor(x => x.EgitimTuru)
			.NotEmpty().WithMessage("Eğitim türü boş olamaz.")
			.MaximumLength(100).WithMessage("Eğitim türü en fazla 100 karakter olabilir.");

			RuleFor(x => x.BaslangicTarihi)
				.NotEmpty().WithMessage("Başlangıç tarihi boş olamaz.")
				.LessThanOrEqualTo(x => DateTime.Now).WithMessage("Başlangıç tarihi gelecekteki bir tarih olamaz.");

			RuleFor(x => x.BitisTarihi)
				.GreaterThanOrEqualTo(x => x.BaslangicTarihi).When(x => x.BitisTarihi.HasValue)
				.WithMessage("Bitiş tarihi, başlangıç tarihinden önce olamaz.");

			RuleFor(x => x.Durum)
				.NotEmpty().WithMessage("Durum boş olamaz.")
				.MaximumLength(50).WithMessage("Durum en fazla 50 karakter olabilir.");

			RuleFor(x => x.Notlar)
				.MaximumLength(500).WithMessage("Notlar en fazla 500 karakter olabilir.");

			RuleFor(x => x.EvcilHayvanID)
				.NotEmpty().WithMessage("Evcil Hayvan ID boş olamaz.")
				.GreaterThanOrEqualTo(1).WithMessage("Evcil Hayvan ID geçersiz.");


		}
}
}

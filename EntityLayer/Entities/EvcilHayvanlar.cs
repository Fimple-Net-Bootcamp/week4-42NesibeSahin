
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace EntityLayer.Entities
{
	public class EvcilHayvanlar : Entity
	{
        
        public string Isim { get; set; }
        public int Kodu { get; set; }
        public string Tur { get; set; }
		public int KullaniciID { get; set; }

		[ForeignKey("KullaniciID")]
		public Kullanici Kullanici { get; set; }


        public List<SaglikDurumlari> SaglikDurumlari { get; set; }
		public List<Aktiviteler> Aktiviteler { get; set; }
		public List<Beslenme> Beslenme { get; set; }
		public List<Egitimler> Egitimler { get; set; }
		public List<SosyalEtkilesimler> SosyalEtkilesimler { get; set; }

	}
}

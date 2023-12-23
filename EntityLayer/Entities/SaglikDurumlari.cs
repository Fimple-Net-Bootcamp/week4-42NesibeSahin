using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Entities
{
	public class SaglikDurumlari : Entity
	{
        public string DurumAdi { get; set; }
        public DateTime Tarih { get; set; }
        public bool HastaMi { get; set; }
        public int EvcilHayvanID { get; set; }

		[ForeignKey("EvcilHayvanID")]
		public EvcilHayvanlar EvcilHayvanlar { get; set; }

		public List<LogSaglik> LogSaglik { get; set; }

	}
}


using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Entities
{
	public class LogSaglik:Entity
	{
        public int SaglikDurumlariID { get; set; }

		public string DurumAdi { get; set; }
		public DateTime Tarih { get; set; }
		public bool HastaMi { get; set; }
		public int EvcilHayvanID { get; set; }

		[ForeignKey("SaglikDurumlariID")]
		public SaglikDurumlari SaglikDurumlari { get; set; }

	}
}

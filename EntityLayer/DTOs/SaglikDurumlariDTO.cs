

namespace EntityLayer.DTOs
{
    public class SaglikDurumlariDTO
    {
        public string DurumAdi { get; set; }
        public bool HastaMi { get; set; }
        public int EvcilHayvanID { get; set; }
    }

    public class SaglikDurumlariCevapDTO
    {
        public string DurumAdi { get; set; }
        public bool HastaMi { get; set; }
        public int EvcilHayvanID { get; set; }
        public DateTime Tarih { get; set; }
    }

	public class LogSaglikDurumlariDTO
	{
		public int EvcilHayvanID { get; set; }
		public string DurumAdi { get; set; }
		public bool HastaMi { get; set; }
		public DateTime Tarih { get; set; }
	}
}

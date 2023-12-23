namespace EntityLayer.DTOs
{
    public class BeslenmeDTO
    {
        public int ID { get; set; }
		public int BesinlerID { get; set; }
		public int EvcilHayvanID { get; set; }
	}

    public class BeslenmeEkleDTO
	{
		public int BesinlerID { get; set; }
	}
	public class LogBeslenmeDTO
	{
		public int EvcilHayvanID { get; set; }
		public int BesinlerID { get; set; }
		public DateTime DegistirmeTarihi { get; set; }
	}
}

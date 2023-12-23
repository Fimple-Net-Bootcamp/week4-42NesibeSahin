namespace EntityLayer.DTOs
{
    public class AktivitelerDTO
    {
        public int ID { get; set; }
        public string Adi { get; set; }
        public int EvcilHayvanID { get; set; }
    }
    public class AktivitelerEkleDTO
    {

        public string Adi { get; set; }
        public int EvcilHayvanID { get; set; }
    }
	public class logAktivitelerDTO
	{
		public int EvcilHayvanID { get; set; }
		public string Adi { get; set; }
	}
}

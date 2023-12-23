namespace EntityLayer.DTOs
{
    public class EgitimlerDTO
    {
        public int ID { get; set; }
        public string EgitimTuru { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public string Durum { get; set; }
        public string Notlar { get; set; }
        public int EvcilHayvanID { get; set; }
    }
    public class EgitimlerEkleDTO
    {
        public string EgitimTuru { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public string Durum { get; set; }
        public string Notlar { get; set; }
        public int EvcilHayvanID { get; set; }
    }

}

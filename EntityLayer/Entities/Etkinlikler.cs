namespace EntityLayer.Entities
{
	public class Etkinlikler:Entity
	{
		public string Ad{ get; set; }
		public DateTime BaslangicTarihi { get; set; }
		public DateTime? BitisTarihi { get; set; }
		public string Konum { get; set; }

		public List<SosyalEtkilesimler> SosyalEtkilesimler { get; set; }
	}
}

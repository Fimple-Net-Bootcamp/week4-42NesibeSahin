using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Entities
{
	public class LogBeslenme:Entity
	{
        public int BeslenmeID { get; set; }
        public DateTime DegistirmeTarihi { get; set; }
		public int BesinlerID { get; set; }
		public int EvcilHayvanID { get; set; }

		[ForeignKey("BeslenmeID")]
		public Beslenme Beslenme { get; set; }

	}
}

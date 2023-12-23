using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Entities
{
	public class Beslenme:Entity
	{
		public int BesinlerID { get; set; }
		public int EvcilHayvanID { get; set; }

		[ForeignKey("EvcilHayvanID")]
		public EvcilHayvanlar EvcilHayvanlar { get; set; }

		[ForeignKey("BesinlerID")]
		public Besinler Besinler { get; set; }

		public List<LogBeslenme> LogBeslenme { get; set; }
	}
}

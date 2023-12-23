using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Entities
{
	public class LogAktivite:Entity
	{
        public  int AktivitelerID { get; set; }
		public string Adi { get; set; }
		public int EvcilHayvanID { get; set; }

		[ForeignKey("AktivitelerID")]
		public Aktiviteler Aktiviteler { get; set; }
	}
}

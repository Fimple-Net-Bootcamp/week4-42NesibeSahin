using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Entities
{
	public class Aktiviteler:Entity
	{
        public string Adi { get; set; }
		public int EvcilHayvanID { get; set; }

		[ForeignKey("EvcilHayvanID")]
		public EvcilHayvanlar EvcilHayvanlar { get; set; }

		public List<LogAktivite> LogAktivite { get; set; }
	}
}


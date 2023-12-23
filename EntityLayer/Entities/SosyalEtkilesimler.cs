using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Entities
{
    public class SosyalEtkilesimler:Entity
    {
        public int EtkinlikID { get; set; }
        public int EvcilHayvanID { get; set; }

        [ForeignKey("EtkinlikID")]
		public Etkinlikler Etkinlikler { get; set; }

		[ForeignKey("EvcilHayvanID")]
		public EvcilHayvanlar EvcilHayvanlar { get; set; }

		
	}
}

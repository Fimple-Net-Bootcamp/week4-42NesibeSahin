

using EntityLayer.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.DTOs
{
    public class SosyalEtkilesimlerDTO
    {
        public int ID { get; set; }
        public int EtkinlikID { get; set; }
		public int EvcilHayvanID { get; set; }
	}

    public class SosyalEtkilesimlerEkleDTO
    {
		public int EtkinlikID { get; set; }
		public int EvcilHayvanID { get; set; }
	}
}

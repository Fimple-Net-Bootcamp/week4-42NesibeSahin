using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Entities
{
	public class Kullanici:Entity
	{
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string TC { get; set; }

        public List<EvcilHayvanlar> EvcilHayvanlar { get; set; }


    }
}

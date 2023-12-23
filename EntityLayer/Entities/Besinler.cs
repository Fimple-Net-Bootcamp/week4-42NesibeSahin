using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Entities
{
	public class Besinler : Entity
	{
        public string Adi { get; set; }

		public List<Beslenme> Beslenme { get; set; }

	}
}


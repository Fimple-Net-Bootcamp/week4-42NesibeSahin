using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Entities
{
	public abstract class Entity
	{
        public int ID { get; set; }
        public bool isSilindi { get; set; }
    }
}

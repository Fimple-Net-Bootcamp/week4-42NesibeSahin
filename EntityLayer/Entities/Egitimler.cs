using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Entities
{
    public class Egitimler: Entity
    {
        public string EgitimTuru { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public string Durum { get; set; }
        public string Notlar { get; set; }
        public int EvcilHayvanID { get; set; }

        [ForeignKey("EvcilHayvanID")]
        public EvcilHayvanlar EvcilHayvanlar { get; set; }
    }
}

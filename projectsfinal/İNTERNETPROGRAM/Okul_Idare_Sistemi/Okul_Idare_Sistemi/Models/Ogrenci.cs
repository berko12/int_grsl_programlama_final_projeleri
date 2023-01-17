using System.ComponentModel.DataAnnotations;

namespace Okul_Idare_Sistemi.Models
{
    public class Ogrenci
    {
        public int Id { get; set; } 

        public string AdSoyad { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime KayitTarih { get; set; }  

        public string OgrenciNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DTarih { get; set; }

        public string Bolum { get; set; }

        public ICollection<OgrenciDers> OgrenciDersler { get; set; }
    }
}

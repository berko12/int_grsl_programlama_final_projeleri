using Microsoft.AspNetCore.Mvc;

namespace Okul_Idare_Sistemi.Models
{
    public class Ders
    {
        public int Id { get; set; }

        public string Ad { get; set; }

        public string Kredisi { get; set; }
       
        public int OkulYonetimId { get; set; }

        public OkulYonetim OkulYonetim { get; set; }   
        
        public ICollection<OgrenciDers> OgrenciDersler { get; set; }
    }
}

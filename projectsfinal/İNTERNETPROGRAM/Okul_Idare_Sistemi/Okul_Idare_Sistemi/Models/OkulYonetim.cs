namespace Okul_Idare_Sistemi.Models
{
    public class OkulYonetim
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string Gorevi { get; set; }
        public string YonetimTip { get; set; }

        public ICollection<Ders> Dersler { get; set; }
    }
}

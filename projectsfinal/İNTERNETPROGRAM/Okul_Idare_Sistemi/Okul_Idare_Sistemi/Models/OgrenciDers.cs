namespace Okul_Idare_Sistemi.Models
{
    public class OgrenciDers
    {
        public int Id { get; set; }

        public int DersId { get; set; }

        public Ders Ders { get; set; }

        public int OgrenciId { get; set; }

        public Ogrenci Ogrenci { get; set; }
    }
}

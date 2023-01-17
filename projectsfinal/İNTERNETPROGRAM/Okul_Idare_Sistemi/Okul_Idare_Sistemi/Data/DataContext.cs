using Microsoft.EntityFrameworkCore;
using Okul_Idare_Sistemi.Models;

namespace Okul_Idare_Sistemi.Data
{
    public class DataContext : DbContext
    {

        public DbSet<Ders> Dersler { get; set; }
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<OgrenciDers> OgrenciDersler { get; set; }
        public DbSet<OkulYonetim> OkulYonetimler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-JSCJ0Q3;Database=OkulIdareSistemi;Trusted_Connection=True");
        }


    }
}

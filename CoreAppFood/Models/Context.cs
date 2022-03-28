
using Microsoft.EntityFrameworkCore;

namespace CoreAppFood.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            //sql bağlantı adresimiz ve veritabanı adımızı yazıyoruz
            dbContextOptionsBuilder.UseSqlServer("server = DESKTOP-ODFOU77; database=DbWebAppCore; integrated security=true");

        }

        //Oluşturacağımız tablolara ait sınıfları tanımlıyoruz
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}

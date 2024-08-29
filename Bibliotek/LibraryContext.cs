using Microsoft.EntityFrameworkCore;

namespace Bibliotek;

public class LibraryContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }


protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        optionsBuilder.UseSqlServer(
            @"Server=EASV-DB4.easv.dk;Database=M_Bibliotek;User Id=CSe2023t_t_4;Password=CSe2023tT4#23;TrustServerCertificate=True");
        }
    }
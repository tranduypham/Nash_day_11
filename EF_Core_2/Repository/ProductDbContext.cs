using Microsoft.EntityFrameworkCore;

namespace EF_Core_2.Models {
    public class ProductDbContext : DbContext {
        public ProductDbContext() { }
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base (options) { }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer("Server=DESKTOP-C00IDIB;Initial Catalog=ProductsEFCore;");
        // }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            // Write Fluent API Configuration here

            // Property Configuration
            modelBuilder.Entity<Category>()
                        .HasKey(cate=>cate.CategoriId);

            modelBuilder.Entity<Category>()
                        .Property(cate => cate.CategoriId)
                        .HasColumnName("Id")
                        .ValueGeneratedOnAdd()
                        .IsRequired();

            modelBuilder.Entity<Category>()
                        .Property(cate=>cate.CategoryName)
                        .HasColumnName("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar")
                        .HasMaxLength(255);

            modelBuilder.Entity<Product>()
                        .HasKey(p=>p.ProductId);

            modelBuilder.Entity<Product>()
                        .Property(p=>p.ProductId)
                        .HasColumnName("Id")
                        .ValueGeneratedOnAdd()
                        .IsRequired();

            modelBuilder.Entity<Product>()
                        .Property(p=>p.ProductName)
                        .HasColumnName("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar")
                        .HasMaxLength(255);

            modelBuilder.Entity<Product>()
                        .Property(p=>p.Manufacture)
                        .HasColumnName("Manufacture")
                        .IsRequired()
                        .HasColumnType("nvarchar")
                        .HasMaxLength(255);
            
            // Configure a relation where 1 product has 1 category and 1 category has many products where each product has a foreign key CategoryId
            modelBuilder.Entity<Product>()
                        .HasOne<Category>()
                        .WithMany()
                        .HasForeignKey(p=>p.CategoryId)
                        .OnDelete(DeleteBehavior.Cascade);

            // Seed data
            modelBuilder.Entity<Category>()
                        .HasData(
                            new Category{
                                CategoriId = 1,
                                CategoryName = "Book"
                            },
                            new Category{
                                CategoriId = 2,
                                CategoryName = "Music"
                            }
                        );
            modelBuilder.Entity<Product>()
                        .HasData(
                            new Product{
                                ProductId = 1,
                                ProductName = "Nghin le mot dem",
                                Manufacture = "NXB GD",
                                CategoryId = 1
                            },
                            new Product{
                                ProductId = 2,
                                ProductName = "1001 chu cho dom",
                                Manufacture = "NXB SG",
                                CategoryId = 1
                            },
                            new Product{
                                ProductId = 3,
                                ProductName = "Dust till dawn",
                                Manufacture = "Sia.Inc",
                                CategoryId = 2
                            },
                            new Product{
                                ProductId = 4,
                                ProductName = "WAP",
                                Manufacture = "Cardi B .TimeLine Record Inc",
                                CategoryId = 2
                            }
                        );
            // modelBuilder.Seed();
        }
    }
}
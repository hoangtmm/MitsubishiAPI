using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
namespace Misubishi.DAL.Entities;
public partial class MitsubishiDbContext : DbContext
{
    public MitsubishiDbContext()
    {
    }

    public MitsubishiDbContext(DbContextOptions<MitsubishiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarCategory> CarCategories { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<QuickQuote> QuickQuotes { get; set; }

    public virtual DbSet<TestDrife> TestDrives { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          => optionsBuilder.UseSqlServer(GetConnectionString());
    private string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();
        var strConn = config["ConnectionStrings:DefaultConnectionStringDB"];

        return strConn;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cars__3213E83F0C24C679");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");

            entity.HasOne(d => d.Category).WithMany(p => p.Cars)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Cars__category_i__398D8EEE");
        });
        modelBuilder.Entity<CarCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CarCateg__3213E83F1ABE11A5");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });
        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__News__3213E83FAA0DA9DF");

            entity.HasIndex(e => e.Slug, "UQ__News__32DD1E4CF0B8F0F5").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.PublishedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("published_at");
            entity.Property(e => e.Slug)
                .HasMaxLength(200)
                .HasColumnName("slug");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");
        });
        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Promotio__3213E83F1C4576C2");

            entity.HasIndex(e => e.Slug, "UQ__Promotio__32DD1E4C58883EBC").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("end_date");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.Slug)
                .HasMaxLength(200)
                .HasColumnName("slug");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");
        });
        modelBuilder.Entity<QuickQuote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__QuickQuo__3213E83F2524CB4B");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CarModel)
                .HasMaxLength(100)
                .HasColumnName("car_model");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("full_name");
            entity.Property(e => e.Message)
                .HasMaxLength(500)
                .HasColumnName("message");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<TestDrife>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TestDriv__3213E83F63270A27");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CarModel)
                .HasMaxLength(100)
                .HasColumnName("car_model");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("full_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.PreferredDate)
                .HasColumnType("datetime")
                .HasColumnName("preferred_date");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("pending")
                .HasColumnName("status");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83FB9185DE9");

            entity.HasIndex(e => e.Username, "UQ__Users__F3DBC572FA3A632C").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

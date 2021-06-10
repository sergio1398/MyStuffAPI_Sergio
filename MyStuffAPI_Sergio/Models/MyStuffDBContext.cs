using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MyStuffAPI_Sergio.Models
{
    public partial class MyStuffDBContext : DbContext
    {
        public MyStuffDBContext()
        {
        }

        public MyStuffDBContext(DbContextOptions<MyStuffDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemCategory> ItemCategories { get; set; }
        public virtual DbSet<ItemLocalization> ItemLocalizations { get; set; }
        public virtual DbSet<Multimedium> Multimedia { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserStatus> UserStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("SERVER=DESKTOP-C2RVGLR;DATABASE=MyStuffDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Brands)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBrand731895");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("Currency");

                entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

                entity.Property(e => e.CurrencyName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CurrencySym)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

                entity.Property(e => e.ExRate)
                    .HasColumnType("decimal(18, 8)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.InvoiceNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ItemCategoryId).HasColumnName("ItemCategoryID");

                entity.Property(e => e.ItemCost).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.ItemDescription)
                    .HasMaxLength(1500)
                    .IsUnicode(false);

                entity.Property(e => e.ItemLocalizationId).HasColumnName("ItemLocalizationID");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FKItem 787314");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKItem 931737");

                entity.HasOne(d => d.ItemCategory)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ItemCategoryId)
                    .HasConstraintName("FKItem 310897");

                entity.HasOne(d => d.ItemLocalization)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ItemLocalizationId)
                    .HasConstraintName("FKItem 125121");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FKItem 190681");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKItem 259876");
            });

            modelBuilder.Entity<ItemCategory>(entity =>
            {
                entity.ToTable("ItemCategory");

                entity.Property(e => e.ItemCategoryId).HasColumnName("ItemCategoryID");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ItemCategories)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKItemCatego550700");
            });

            modelBuilder.Entity<ItemLocalization>(entity =>
            {
                entity.ToTable("ItemLocalization");

                entity.Property(e => e.ItemLocalizationId).HasColumnName("ItemLocalizationID");

                entity.Property(e => e.Localization)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ItemLocalizations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKItemLocali309633");
            });

            modelBuilder.Entity<Multimedium>(entity =>
            {
                entity.HasKey(e => e.MultimediaId)
                    .HasName("PK__Multimed__35412A69B55A65AE");

                entity.Property(e => e.MultimediaId).HasColumnName("MultimediaID");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.MultimediaUri)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("MultimediaURI");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Multimedia)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKMultimedia62667");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.SupplierEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierPhone)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKSupplier376194");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.BackupEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastLogin)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UserStatusId).HasColumnName("UserStatusID");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserStatus)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKUser943402");
            });

            modelBuilder.Entity<UserStatus>(entity =>
            {
                entity.ToTable("UserStatus");

                entity.Property(e => e.UserStatusId).HasColumnName("UserStatusID");

                entity.Property(e => e.UserStatus1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserStatus");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShopBasketWeb.Models
{
    public partial class GroceryDBContext : DbContext
    {
        public GroceryDBContext()
        {
        }

        public GroceryDBContext(DbContextOptions<GroceryDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<PriceInfo> PriceInfo { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductInfo> ProductInfo { get; set; }
        public virtual DbSet<ShoppingList> ShoppingList { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:marketserverbtech.database.windows.net;Database=GroceryDB;User ID=Maurice;Password=Whicod22;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CatId);

                entity.Property(e => e.CatId).HasColumnName("CatID");

                entity.Property(e => e.CatName).HasMaxLength(50);
            });

            modelBuilder.Entity<PriceInfo>(entity =>
            {
                entity.HasKey(e => e.PriceId);

                entity.ToTable("Price_Info");

                entity.Property(e => e.PriceId).HasColumnName("PriceID");

                entity.Property(e => e.CurrentPrice)
                    .HasColumnName("Current_Price")
                    .HasColumnType("money");

                entity.Property(e => e.CurrentPriceDate)
                    .HasColumnName("CurrentPrice_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PreviousPrceDate)
                    .HasColumnName("PreviousPrce_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PreviousPrice)
                    .HasColumnName("Previous_Price")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Barcode);

                entity.Property(e => e.Barcode)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.CatId).HasColumnName("catID");

                entity.Property(e => e.ProdDescription).HasMaxLength(50);

                entity.Property(e => e.ProdImg).HasColumnType("image");

                entity.Property(e => e.ProdName).HasMaxLength(50);

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Category");
            });

            modelBuilder.Entity<ProductInfo>(entity =>
            {
                entity.HasKey(e => e.ProductInfo1);

                entity.ToTable("Product_Info");

                entity.Property(e => e.ProductInfo1)
                    .HasColumnName("ProductInfo#")
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Barcode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PriceId).HasColumnName("PriceID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.HasOne(d => d.BarcodeNavigation)
                    .WithMany(p => p.ProductInfo)
                    .HasForeignKey(d => d.Barcode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Info_Product");

                entity.HasOne(d => d.Price)
                    .WithMany(p => p.ProductInfo)
                    .HasForeignKey(d => d.PriceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Info_Price_Info");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.ProductInfo)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Info_Store");
            });

            modelBuilder.Entity<ShoppingList>(entity =>
            {
                entity.HasKey(e => new { e.UserName, e.Barcode });

                entity.Property(e => e.UserName).HasMaxLength(250);

                entity.Property(e => e.Barcode).HasMaxLength(50);

                entity.HasOne(d => d.BarcodeNavigation)
                    .WithMany(p => p.ShoppingList)
                    .HasForeignKey(d => d.Barcode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShoppingList_Product");

                entity.HasOne(d => d.UserNameNavigation)
                    .WithMany(p => p.ShoppingList)
                    .HasForeignKey(d => d.UserName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShoppingList_User");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.Latitude).HasMaxLength(50);

                entity.Property(e => e.Longitude).HasMaxLength(50);

                entity.Property(e => e.StoreName)
                    .HasColumnName("Store_Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserName);

                entity.Property(e => e.UserName)
                    .HasMaxLength(250)
                    .ValueGeneratedNever();

                entity.Property(e => e.Latitude).HasMaxLength(250);

                entity.Property(e => e.Longitude).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Surename)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_UserType");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.UserTitle)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}

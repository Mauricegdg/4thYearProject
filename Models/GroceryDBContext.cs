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
        public virtual DbSet<ListProductInfo> ListProductInfo { get; set; }
        public virtual DbSet<PriceInfo> PriceInfo { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductInfo> ProductInfo { get; set; }
        public virtual DbSet<ShoppingList> ShoppingList { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<User> User { get; set; }

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

                entity.Property(e => e.CatId)
                    .HasColumnName("CatID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ListProductInfo>(entity =>
            {
                entity.HasKey(e => new { e.ListId, e.ProductInfo });

                entity.ToTable("List_productInfo");

                entity.Property(e => e.ListId).HasColumnName("ListID");

                entity.Property(e => e.ProductInfo).HasColumnName("ProductInfo#");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.HasOne(d => d.List)
                    .WithMany(p => p.ListProductInfo)
                    .HasForeignKey(d => d.ListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_List_productInfo_ShoppingList");

                entity.HasOne(d => d.ProductInfoNavigation)
                    .WithMany(p => p.ListProductInfo)
                    .HasForeignKey(d => d.ProductInfo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_List_productInfo_Product_Info");
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

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

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
                entity.HasKey(e => e.ListId);

                entity.Property(e => e.ListId)
                    .HasColumnName("listID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ItemList).IsUnicode(false);

                entity.Property(e => e.TotalCost).HasColumnType("money");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.UserNameNavigation)
                    .WithMany(p => p.ShoppingList)
                    .HasForeignKey(d => d.UserName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShoppingList_User");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.StroreId);

                entity.Property(e => e.StroreId)
                    .HasColumnName("StroreID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Latitude).HasMaxLength(50);

                entity.Property(e => e.Longitude).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
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

                entity.Property(e => e.Salt).HasMaxLength(250);

                entity.Property(e => e.Surename).HasMaxLength(50);
            });
        }
    }
}

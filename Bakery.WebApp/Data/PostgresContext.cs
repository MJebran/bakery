using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Bakery.WebApp.Data;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customitem> Customitems { get; set; }

    public virtual DbSet<Favoriteitem> Favoriteitems { get; set; }

    public virtual DbSet<Itempurchase> Itempurchases { get; set; }

    public virtual DbSet<Itemtype> Itemtypes { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<Topping> Toppings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    //we do not need this 
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseNpgsql("Name=db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("pg_catalog", "azure")
            .HasPostgresExtension("pg_catalog", "pgaadauth");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("category_pkey");

            entity.ToTable("category", "Bakery");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryDescription).HasColumnName("category_description");
            entity.Property(e => e.CategoryName).HasColumnName("category_name");
        });

        modelBuilder.Entity<Customitem>(entity =>
        {
            entity.HasKey(e => e.CustomItemId).HasName("customitem_pkey");

            entity.ToTable("customitem", "Bakery");

            entity.Property(e => e.CustomItemId).HasColumnName("custom_item_id");
            entity.Property(e => e.CustomItemToppingQuantity).HasColumnName("custom_item_topping_quantity");
            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.ToppingId).HasColumnName("topping_id");

            entity.HasOne(d => d.Item).WithMany(p => p.Customitems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("customitem_item_id_fkey");

            entity.HasOne(d => d.Topping).WithMany(p => p.Customitems)
                .HasForeignKey(d => d.ToppingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("customitem_topping_id_fkey");
        });

        modelBuilder.Entity<Favoriteitem>(entity =>
        {
            entity.HasKey(e => e.FavoriteitemId).HasName("favoriteitem_pkey");

            entity.ToTable("favoriteitem", "Bakery");

            entity.Property(e => e.FavoriteitemId).HasColumnName("favoriteitem_id");
            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Item).WithMany(p => p.Favoriteitems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("favoriteitem_item_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Favoriteitems)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("favoriteitem_user_id_fkey");
        });

        modelBuilder.Entity<Itempurchase>(entity =>
        {
            entity.HasKey(e => e.ItempurchaseId).HasName("itempurchase_pkey");

            entity.ToTable("itempurchase", "Bakery");

            entity.Property(e => e.ItempurchaseId).HasColumnName("itempurchase_id");
            entity.Property(e => e.ItempurchaseItemId).HasColumnName("itempurchase_item_id");
            entity.Property(e => e.ItempurchaseQuantity).HasColumnName("itempurchase_quantity");
            entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");

            entity.HasOne(d => d.ItempurchaseItem).WithMany(p => p.Itempurchases)
                .HasForeignKey(d => d.ItempurchaseItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("itempurchase_itempurchase_item_id_fkey");

            entity.HasOne(d => d.Purchase).WithMany(p => p.Itempurchases)
                .HasForeignKey(d => d.PurchaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("itempurchase_purchase_id_fkey");
        });

        modelBuilder.Entity<Itemtype>(entity =>
        {
            entity.HasKey(e => e.ItemTypeId).HasName("itemtype_pkey");

            entity.ToTable("itemtype", "Bakery");

            entity.Property(e => e.ItemTypeId).HasColumnName("item_type_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.ItemDescription).HasColumnName("item_description");
            entity.Property(e => e.ItemName).HasColumnName("item_name");
            entity.Property(e => e.ItemPrice).HasColumnName("item_price");
            entity.Property(e => e.ItemWeight).HasColumnName("item_weight");
            entity.Property(e => e.ItmeCalories).HasColumnName("itme_calories");
            entity.Property(e => e.SizeId).HasColumnName("size_id");

            entity.HasOne(d => d.Category).WithMany(p => p.Itemtypes)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("itemtype_category_id_fkey");

            entity.HasOne(d => d.Size).WithMany(p => p.Itemtypes)
                .HasForeignKey(d => d.SizeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("itemtype_size_id_fkey");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.PurchaseId).HasName("purchase_pkey");

            entity.ToTable("purchase", "Bakery");

            entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");
            entity.Property(e => e.Ispayed).HasColumnName("ispayed");
            entity.Property(e => e.PurcahseDate).HasColumnName("purcahse_date");
            entity.Property(e => e.PurchaseUserId).HasColumnName("purchase_user_id");

            entity.HasOne(d => d.PurchaseUser).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.PurchaseUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("purchase_purchase_user_id_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("role_pkey");

            entity.ToTable("role", "Bakery");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleDescription).HasColumnName("role_description");
            entity.Property(e => e.RoleName).HasColumnName("role_name");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.SizeId).HasName("size_pkey");

            entity.ToTable("size", "Bakery");

            entity.Property(e => e.SizeId).HasColumnName("size_id");
            entity.Property(e => e.SizeName)
                .HasMaxLength(15)
                .HasColumnName("size_name");
        });

        modelBuilder.Entity<Topping>(entity =>
        {
            entity.HasKey(e => e.ToppingId).HasName("topping_pkey");

            entity.ToTable("topping", "Bakery");

            entity.Property(e => e.ToppingId).HasColumnName("topping_id");
            entity.Property(e => e.ToppingCalories).HasColumnName("topping_calories");
            entity.Property(e => e.ToppingName).HasColumnName("topping_name");
            entity.Property(e => e.ToppingPrice).HasColumnName("topping_price");
            entity.Property(e => e.ToppingUnit).HasColumnName("topping_unit");
            entity.Property(e => e.ToppingWeight).HasColumnName("topping_weight");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("user_pkey");

            entity.ToTable("user", "Bakery");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserEmail).HasColumnName("user_email");
            entity.Property(e => e.UserName).HasColumnName("user_name");
            entity.Property(e => e.UserPhone).HasColumnName("user_phone");
            entity.Property(e => e.UserRoleId).HasColumnName("user_role_id");

            entity.HasOne(d => d.UserRole).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_user_role_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

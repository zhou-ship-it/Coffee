using Coffee.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;

namespace Coffee.DAL.Entity;

public partial class DbModel : DbContext
{
    public DbModel()
    {
    }

    public DbModel(DbContextOptions<DbModel> options)
        : base(options)
    {
    }
    /// <summary>
    /// Table entities
    /// </summary>
    public virtual DbSet<Additional> Additionals { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<IngredientLoss> IngredientLosses { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<ProductLostAndDamage> ProductLostAndDamages { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<SupplierPayment> SupplierPayments { get; set; }

    public virtual DbSet<Tax> Taxes { get; set; }

    public virtual DbSet<OrderTaxDetail> OrderTaxDetails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("server=.;Database=OKDone;Trusted_Connection=True;TrustServerCertificate=True;");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Converter_Section
        var OrderStatusConverter = new ValueConverter<General.Common.OrderStatus, string>(
                v => v == General.Common.OrderStatus.Delivered ? "DL" :
                     v == General.Common.OrderStatus.Processing ? "PR" :
                     v == General.Common.OrderStatus.Completed ? "CP" :
                     v == General.Common.OrderStatus.Cancelled ? "CA" : "PN",
                v => v == "DL" ? General.Common.OrderStatus.Delivered :
                     v == "PR" ? General.Common.OrderStatus.Processing :
                     v == "CP" ? General.Common.OrderStatus.Completed :
                     v == "CA" ? General.Common.OrderStatus.Cancelled :
                     General.Common.OrderStatus.Pending
        );
        
         var MenuStatusConverter = new ValueConverter<General.Common.MenuStatus, string>(
                v => v == General.Common.MenuStatus.OutOfStock ? "OS" :
                     v == General.Common.MenuStatus.Discontinued ? "DC" :
                     v == General.Common.MenuStatus.Hidden ? "HI" :"AV",
                   
                v => v == "OS" ? General.Common.MenuStatus.OutOfStock:
                     v == "DC" ? General.Common.MenuStatus.Discontinued :
                     v == "HI" ? General.Common.MenuStatus.Hidden :
                     General.Common.MenuStatus.Available
        );
        #endregion

        #region FluentAPI Section
        modelBuilder.Entity<Additional>(entity =>
                {
                    entity.ToTable("Additional")
                        .HasKey(e => new { e.OrderId, e.ProductId, e.IngredientId });

                    entity.HasOne(d => d.Ingredient).WithMany(p => p.Additionals)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Additional_Ingredient");

                    entity.HasOne(d => d.OrderDetail).WithMany(p => p.Additionals)
                                    .OnDelete(DeleteBehavior.ClientSetNull)
                                    .HasConstraintName("FK_Additional_OrderDetail");

                    entity.HasOne(d => d.Ingredient).WithMany(p => p.Additionals)
                                    .OnDelete(DeleteBehavior.ClientSetNull)
                                    .HasConstraintName("FK_Additional_Ingredient");
                });
        //
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category")
                .HasKey(e => e.CategoryId);
        });
        //
        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.ToTable("Ingredient")
                .HasKey(e => e.IngredientId);
        });
        //
        modelBuilder.Entity<IngredientLoss>(entity =>
        {
            entity.ToTable("IngredientLoss")
                .HasKey(e => e.IngredientLossId);
            entity.HasOne(d => d.Ingredient).WithMany(p => p.IngredientLosses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IngredientLoss_Ingredient");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.ToTable("Menu")
                .HasKey(e => e.ProductId);
            entity.HasOne(d => d.Category).WithMany(p => p.Menus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Menu_Category");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order")
                .HasKey(e => e.OrderId);
            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasConstraintName("FK_Order_User");

            // 
            entity.Property(e => e.Status)
                .HasConversion(OrderStatusConverter);

        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.ToTable("OrderDetail")
                .HasKey(e => new { e.OrderId, e.ProductId });
            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetail_Order");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetail_Menu");
        });
        //
        modelBuilder.Entity<OrderTaxDetail>(entity =>
        {
            entity.ToTable("OrderTaxDetail")
                .HasKey(e => new { e.OrderId, e.TaxId });
            entity.HasOne(d => d.Order).WithMany(p => p.OrderTaxDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderTaxDetail_Order");

            entity.HasOne(d => d.Tax).WithMany(p => p.OrderTaxDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderTaxDetail_Tax");
        });
        //
        modelBuilder.Entity<ProductLostAndDamage>(entity =>
        {
            entity.ToTable("ProductLostAndDamage")
                .HasKey(e => e.LossId);
            entity.HasOne(d => d.Product).WithMany(p => p.ProductLostAndDamages)
                .HasConstraintName("FK_ProductLostAndDamage_Menu");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.ToTable("Purchase")
               .HasKey(e => e.PurchaseId);
            entity.HasOne(d => d.Supplier).WithMany(p => p.Purchases)
                .HasConstraintName("FK_Purchase_Supplier");

            entity.HasOne(d => d.User).WithMany(p => p.Purchases)
                .HasConstraintName("FK_Purchase_User");
        });
        //
        modelBuilder.Entity<PurchaseDetail>(entity =>
        {
            entity.ToTable("PurchaseDetail")
                .HasKey(e => new { e.PurchaseId, e.IngredientId });

            entity.HasOne(d => d.Ingredient).WithMany(p => p.PurchaseDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseDetail_Ingredient");

            entity.HasOne(d => d.Purchase).WithMany(p => p.PurchaseDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseDetail_Purchase");
        });
        //
        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.ToTable("Receipe")
                .HasKey(e => new { e.ProductId, e.IngredientId });
            entity.HasOne(d => d.Ingredient).WithMany(p => p.Recipes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Recipe_Ingredient");

            entity.HasOne(d => d.Product).WithMany(p => p.Recipes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Recipe_Product");
        });
        //
        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.ToTable("Supplier")
                .HasKey(e => e.SupplierId);
        });
        modelBuilder.Entity<SupplierPayment>(entity =>
        {
            entity.ToTable("SupplierPayment")
                 .HasKey(e => e.SupplierPaymentId);
            entity.HasOne(d => d.Purchase).WithMany(p => p.SupplierPayments)
                .HasConstraintName("FK_SupplierPayment_Purchase");
        });

        modelBuilder.Entity<Tax>(entity =>
        {
            entity.ToTable("Tax")
                .HasKey(e => e.TaxId);
        });
        //
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User")
                .HasKey(e => e.UserId);
        });
    }
        #endregion
}

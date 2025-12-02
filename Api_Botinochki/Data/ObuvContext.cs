using System;
using System.Collections.Generic;
using Api_Botinochki.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Botinochki.Data;

public partial class ObuvContext : DbContext
{
    public ObuvContext()
    {
    }

    public ObuvContext(DbContextOptions<ObuvContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductName> ProductNames { get; set; }

    public virtual DbSet<ProductСategory> ProductСategories { get; set; }

    public virtual DbSet<Pvz> Pvzs { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=OBUV;Trusted_Connection=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.ToTable("Manufacturer");

            entity.Property(e => e.ManufacturerId).HasColumnName("Manufacturer_ID");
            entity.Property(e => e.ManufacturerName)
                .HasMaxLength(255)
                .HasColumnName("Manufacturer_Name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderNumberId);

            entity.ToTable("Order");

            entity.Property(e => e.OrderNumberId).HasColumnName("Order_Number_ID");
            entity.Property(e => e.DeliveryDate)
                .HasColumnType("datetime")
                .HasColumnName("Delivery _Date");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("Order_Date");
            entity.Property(e => e.OrderStatusId).HasColumnName("Order_Status_ID");
            entity.Property(e => e.PvzId).HasColumnName("PVZ_ID");
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatusId)
                .HasConstraintName("FK_Order_Order_Status");

            entity.HasOne(d => d.Pvz).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PvzId)
                .HasConstraintName("FK_Order_PVZ");

           
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.ToTable("Order_Items");

            entity.Property(e => e.OrderItemId).HasColumnName("Order_Item_ID ");
            entity.Property(e => e.OrderNumberId).HasColumnName("Order_Number_ID");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID ");

            entity.HasOne(d => d.OrderNumber).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderNumberId)
                .HasConstraintName("FK_Order_Items_Order");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Order_Items_Product");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.ToTable("Order_Status");

            entity.Property(e => e.OrderStatusId).HasColumnName("Order_Status_ID");
            entity.Property(e => e.OrderStatusName)
                .HasMaxLength(255)
                .HasColumnName("Order_Status_Name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            entity.Property(e => e.CurrentDiscount).HasColumnName("Current_Discount");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.ManufacturerId).HasColumnName("Manufacturer_ID");
            entity.Property(e => e.Photo).HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.ProductArticle)
                .HasMaxLength(255)
                .HasColumnName("Product_Article ");
            entity.Property(e => e.ProductNameId).HasColumnName("Product_Name_ID");
            entity.Property(e => e.ProductСategoryId).HasColumnName("Product_Сategory_ID");
            entity.Property(e => e.QuantityStock).HasColumnName("Quantity _Stock");
            entity.Property(e => e.SupplierId).HasColumnName("Supplier_ID");
            entity.Property(e => e.Unit).HasMaxLength(255);

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Products)
                .HasForeignKey(d => d.ManufacturerId)
                .HasConstraintName("FK_Product_Manufacturer");

            entity.HasOne(d => d.ProductName).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductNameId)
                .HasConstraintName("FK_Product_Product_Name");

            entity.HasOne(d => d.ProductСategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductСategoryId)
                .HasConstraintName("FK_Product_Product_Сategory");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_Product_Supplier");
        });

        modelBuilder.Entity<ProductName>(entity =>
        {
            entity.ToTable("Product_Name");

            entity.Property(e => e.ProductNameId).HasColumnName("Product_Name_ID");
            entity.Property(e => e.ProductName1)
                .HasMaxLength(255)
                .HasColumnName("Product_Name");
        });

        modelBuilder.Entity<ProductСategory>(entity =>
        {
            entity.ToTable("Product_Сategory");

            entity.Property(e => e.ProductСategoryId).HasColumnName("Product_Сategory_ID");
            entity.Property(e => e.ProductСategoryName)
                .HasMaxLength(255)
                .HasColumnName("Product_Сategory_Name");
        });

        modelBuilder.Entity<Pvz>(entity =>
        {
            entity.ToTable("PVZ");

            entity.Property(e => e.PvzId).HasColumnName("PVZ_ID");
            entity.Property(e => e.PvzName)
                .HasMaxLength(255)
                .HasColumnName("PVZ_Name");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.ToTable("Supplier");

            entity.Property(e => e.SupplierId).HasColumnName("Supplier_ID");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(255)
                .HasColumnName("Supplier_Name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.Fio)
                .HasMaxLength(255)
                .HasColumnName("FIO");
            entity.Property(e => e.Login).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.UserRoleId).HasColumnName("User_Role_ID");

           
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.ToTable("User_Role");

            entity.Property(e => e.UserRoleId).HasColumnName("User_Role_ID");
            entity.Property(e => e.UserRole1)
                .HasMaxLength(255)
                .HasColumnName("User_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

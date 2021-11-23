using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_049_A.Models
{
    public partial class UCP1Context : DbContext
    {
        public UCP1Context()
        {
        }

        public UCP1Context(DbContextOptions<UCP1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Cashier> Cashiers { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DeliveryTeam> DeliveryTeams { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cashier>(entity =>
            {
                entity.HasKey(e => e.IdCashier);

                entity.ToTable("Cashier");

                entity.Property(e => e.IdCashier)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Cashier");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NamaKasir)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Kasir");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);

                entity.ToTable("Customer");

                entity.Property(e => e.IdCustomer)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Customer");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreditLimit).HasColumnType("numeric(19, 0)");

                entity.Property(e => e.NamaCustomer)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Customer");
            });

            modelBuilder.Entity<DeliveryTeam>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("DeliveryTeam");

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NameEmployee)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Name_Employee");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("PK_Order_1");

                entity.ToTable("Order");

                entity.Property(e => e.IdOrder)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Order");

                entity.Property(e => e.Comment)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdOrderProduct).HasColumnName("ID_OrderProduct");

                entity.Property(e => e.IdStatus).HasColumnName("ID_Status");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.RequiredDate).HasColumnType("datetime");

                entity.Property(e => e.ShippedDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdOrderProductNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdOrderProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_1_OrderProduct");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_1_Status");
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.HasKey(e => e.IdOrderProduct);

                entity.ToTable("OrderProduct");

                entity.Property(e => e.IdOrderProduct)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_OrderProduct");

                entity.Property(e => e.IdProduct).HasColumnName("ID_Product");

                entity.Property(e => e.PriceEach).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderProduct_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct);

                entity.ToTable("Product");

                entity.Property(e => e.IdProduct)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Product");

                entity.Property(e => e.BuyPrice).HasColumnType("numeric(19, 0)");

                entity.Property(e => e.Msrp)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("MSRP");

                entity.Property(e => e.NameProduct)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name_Product");

                entity.Property(e => e.PdtDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProductionlineId).HasColumnName("ProductionlineID");

                entity.Property(e => e.Vendor)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.IdStatus);

                entity.ToTable("Status");

                entity.Property(e => e.IdStatus)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Status");

                entity.Property(e => e.Status1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

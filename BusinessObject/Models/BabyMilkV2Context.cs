using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BusinessObject.Models
{
    public partial class BabyMilkV2Context : DbContext
    {
        public BabyMilkV2Context()
        {
        }

        public BabyMilkV2Context(DbContextOptions<BabyMilkV2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Baby> Babies { get; set; } = null!;
        public virtual DbSet<BabyDevelopment> BabyDevelopments { get; set; } = null!;
        public virtual DbSet<BabyTakeCare> BabyTakeCares { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Development> Developments { get; set; } = null!;
        public virtual DbSet<MilestonesByMonth> MilestonesByMonths { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<OrderVoucher> OrderVouchers { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductBabyDevelopment> ProductBabyDevelopments { get; set; } = null!;
        public virtual DbSet<TakeCareDevelopment> TakeCareDevelopments { get; set; } = null!;
        public virtual DbSet<UserVoucher> UserVouchers { get; set; } = null!;
        public virtual DbSet<Voucher> Vouchers { get; set; } = null!;

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseSqlServer("Server=(local);Uid=ntp;Pwd=123456;Database=BabyMilkV2");
        //            }
        //        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var d = Directory.GetCurrentDirectory();
            IConfigurationRoot configuration = builder.Build();
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email")
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password")
                    .IsFixedLength();

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone_number")
                    .IsFixedLength();

                entity.Property(e => e.Role)
                    .HasMaxLength(100)
                    .HasColumnName("role");
            });

            modelBuilder.Entity<Baby>(entity =>
            {
                entity.ToTable("Baby");

                entity.Property(e => e.BabyId).HasColumnName("baby_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .HasColumnName("gender");

                entity.Property(e => e.Height)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("height");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Weight)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("weight");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Babies)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Baby__account_id__267ABA7A");
            });

            modelBuilder.Entity<BabyDevelopment>(entity =>
            {
                entity.ToTable("BabyDevelopment");

                entity.Property(e => e.BabyDevelopmentId).HasColumnName("baby_development_id");

                entity.Property(e => e.BabyId).HasColumnName("baby_id");

                entity.Property(e => e.DevelopmentId).HasColumnName("development_id");

                entity.HasOne(d => d.Baby)
                    .WithMany(p => p.BabyDevelopments)
                    .HasForeignKey(d => d.BabyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BabyDevel__baby___29572725");

                entity.HasOne(d => d.Development)
                    .WithMany(p => p.BabyDevelopments)
                    .HasForeignKey(d => d.DevelopmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BabyDevel__devel__300424B4");
            });

            modelBuilder.Entity<BabyTakeCare>(entity =>
            {
                entity.ToTable("BabyTakeCare");

                entity.Property(e => e.BabyTakeCareId).HasColumnName("baby_take_care_id");

                entity.Property(e => e.Month).HasColumnName("month");

                entity.Property(e => e.Post).HasColumnName("post");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.BrandName)
                    .HasMaxLength(100)
                    .HasColumnName("brand_name");
            });

            modelBuilder.Entity<Development>(entity =>
            {
                entity.ToTable("Development");

                entity.Property(e => e.DevelopmentId).HasColumnName("development_id");

                entity.Property(e => e.Descript)
                    .HasColumnType("text")
                    .HasColumnName("descript");

                entity.Property(e => e.MaxMonth).HasColumnName("max_month");

                entity.Property(e => e.MinMonth).HasColumnName("min_month");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<MilestonesByMonth>(entity =>
            {
                entity.ToTable("MilestonesByMonth");

                entity.Property(e => e.MilestonesByMonthId).HasColumnName("milestones_by_month_id");

                entity.Property(e => e.MaxMonth).HasColumnName("max_month");

                entity.Property(e => e.MinMonth).HasColumnName("min_month");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("order_date");

                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("order_status");

                entity.Property(e => e.Prices)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("prices");

                entity.Property(e => e.ProductVoucherId).HasColumnName("product_voucher_id");

                entity.Property(e => e.ShippedDate)
                    .HasColumnType("date")
                    .HasColumnName("shipped_date");

                entity.Property(e => e.ShippingAddress)
                    .HasMaxLength(200)
                    .HasColumnName("shipping_address");

                entity.Property(e => e.TotalQuantity).HasColumnName("total_quantity");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__account___398D8EEE");

                entity.HasOne(d => d.ProductVoucher)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductVoucherId)
                    .HasConstraintName("FK__Orders__product___3A81B327");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderDetailsId)
                    .HasName("PK__OrderDet__F6FB5AE44693446F");

                entity.Property(e => e.OrderDetailsId).HasColumnName("order_details_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UnitPrice).HasColumnName("unit_price");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__order__38996AB5");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__produ__01142BA1");
            });

            modelBuilder.Entity<OrderVoucher>(entity =>
            {
                entity.ToTable("OrderVoucher");

                entity.Property(e => e.OrderVoucherId).HasColumnName("order_voucher_id");

                entity.Property(e => e.VoucherId).HasColumnName("voucher_id");

                entity.HasOne(d => d.Voucher)
                    .WithMany(p => p.OrderVouchers)
                    .HasForeignKey(d => d.VoucherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrderVoucher_Voucher_voucher_id_fk");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.TokenPayment).HasMaxLength(256);

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("type");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Payment__account__3D5E1FD2");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Payment__order_i__3E52440B");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Img)
                    .HasMaxLength(100)
                    .HasColumnName("img");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price");

                entity.Property(e => e.ProductBabyDevelopmentId).HasColumnName("product_baby_development_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .HasColumnName("status");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__brand_i__4222D4EF");
            });

            modelBuilder.Entity<ProductBabyDevelopment>(entity =>
            {
                entity.ToTable("ProductBabyDevelopment");

                entity.Property(e => e.ProductBabyDevelopmentId).HasColumnName("product_baby_development_id");

                entity.Property(e => e.MilestonesByMonthId).HasColumnName("milestones_by_month_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.MilestonesByMonth)
                    .WithMany(p => p.ProductBabyDevelopments)
                    .HasForeignKey(d => d.MilestonesByMonthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductBa__miles__44FF419A");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductBabyDevelopments)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductBa__produ__6477ECF3");
            });

            modelBuilder.Entity<TakeCareDevelopment>(entity =>
            {
                entity.ToTable("TakeCareDevelopment");

                entity.Property(e => e.TakeCareDevelopmentId).HasColumnName("take_care_development_id");

                entity.Property(e => e.BabyTakeCareId).HasColumnName("baby_take_care_id");

                entity.Property(e => e.DevelopmentId).HasColumnName("development_id");

                entity.HasOne(d => d.BabyTakeCare)
                    .WithMany(p => p.TakeCareDevelopments)
                    .HasForeignKey(d => d.BabyTakeCareId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TakeCareD__baby___48CFD27E");

                entity.HasOne(d => d.Development)
                    .WithMany(p => p.TakeCareDevelopments)
                    .HasForeignKey(d => d.DevelopmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TakeCareD__devel__49C3F6B7");
            });

            modelBuilder.Entity<UserVoucher>(entity =>
            {
                entity.ToTable("UserVoucher");

                entity.Property(e => e.UserVoucherId).HasColumnName("user_voucher_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.VoucherId).HasColumnName("voucher_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.UserVouchers)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserVouch__accou__4CA06362");

                entity.HasOne(d => d.Voucher)
                    .WithMany(p => p.UserVouchers)
                    .HasForeignKey(d => d.VoucherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserVouch__vouch__5070F446");
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.ToTable("Voucher");

                entity.Property(e => e.VoucherId).HasColumnName("voucher_id");

                entity.Property(e => e.Discount)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("discount");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .HasColumnName("type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

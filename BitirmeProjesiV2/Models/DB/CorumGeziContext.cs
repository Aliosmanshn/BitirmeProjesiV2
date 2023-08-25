using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BitirmeProjesiV2.Models.DB;

public partial class CorumGeziContext : DbContext
{
    public CorumGeziContext()
    {
    }

    public CorumGeziContext(DbContextOptions<CorumGeziContext> options): base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Executive> Executives { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Invoicedetail> Invoicedetails { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderdetail> Orderdetails { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Town> Towns { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CorumGezi;User Id =sa;Password=Ali123456.; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Address");

            entity.ToTable("ADDRESS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Addresstext)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ADDRESSTEXT");
            entity.Property(e => e.Cityid).HasColumnName("CITYID");
            entity.Property(e => e.Countryid).HasColumnName("COUNTRYID");
            entity.Property(e => e.Districtid).HasColumnName("DISTRICTID");
            entity.Property(e => e.Postalcode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("POSTALCODE");
            entity.Property(e => e.Townid).HasColumnName("TOWNID");
            entity.Property(e => e.Userid).HasColumnName("USERID");

            entity.HasOne(d => d.City).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.Cityid)
                .HasConstraintName("FK_ADDRESS_CITIES");

            entity.HasOne(d => d.Country).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.Countryid)
                .HasConstraintName("FK_ADDRESS_COUNTRIES");

            entity.HasOne(d => d.District).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.Districtid)
                .HasConstraintName("FK_ADDRESS_DISTRICTS");

            entity.HasOne(d => d.Town).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.Townid)
                .HasConstraintName("FK_ADDRESS_TOWNS");

            entity.HasOne(d => d.User).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("FK_Adresler_Kullanıcı");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Kategoriid).HasName("PK_Tbl_Kategoriler");

            entity.Property(e => e.CategoryImg)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Cities");

            entity.ToTable("CITIES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.City1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CITY");
            entity.Property(e => e.Countryid).HasColumnName("COUNTRYID");

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.Countryid)
                .HasConstraintName("FK_Sehirler_Ulkeler");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Yorumid).HasName("PK_Tbl_Yorumlar");

            entity.ToTable("Comment");

            entity.Property(e => e.CommentContents)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CommentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.CommentMail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CommentNameSurname)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Trip).WithMany(p => p.Comments)
                .HasForeignKey(d => d.TripId)
                .HasConstraintName("FK_Yorumlar_Geziler");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Countries");

            entity.ToTable("COUNTRIES");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Country1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("COUNTRY");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Districts");

            entity.ToTable("DISTRICTS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.District1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DISTRICT");
            entity.Property(e => e.Townid).HasColumnName("TOWNID");

            entity.HasOne(d => d.Town).WithMany(p => p.Districts)
                .HasForeignKey(d => d.Townid)
                .HasConstraintName("FK_Semptler_Ilceler");
        });

        modelBuilder.Entity<Executive>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Executive");

            entity.Property(e => e.YoneticiAd)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.YoneticiSifre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Invoıces");

            entity.ToTable("INVOICES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Addressid).HasColumnName("ADDRESSID");
            entity.Property(e => e.Cargoficheno)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CARGOFICHENO");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("DATE_");
            entity.Property(e => e.Orderid).HasColumnName("ORDERID");
            entity.Property(e => e.Totalprice).HasColumnName("TOTALPRICE");

            entity.HasOne(d => d.Order).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("FK_INVOICES_ORDERS");
        });

        modelBuilder.Entity<Invoicedetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_InvoiceDetails");

            entity.ToTable("INVOICEDETAILS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Amount).HasColumnName("AMOUNT");
            entity.Property(e => e.Invoiceid).HasColumnName("INVOICEID");
            entity.Property(e => e.Itemid).HasColumnName("ITEMID");
            entity.Property(e => e.Linetotal).HasColumnName("LINETOTAL");
            entity.Property(e => e.Orderdetailid).HasColumnName("ORDERDETAILID");
            entity.Property(e => e.Unitprice).HasColumnName("UNITPRICE");

            entity.HasOne(d => d.Invoice).WithMany(p => p.Invoicedetails)
                .HasForeignKey(d => d.Invoiceid)
                .HasConstraintName("FK_INVOICEDETAILS_INVOICES");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemsId).HasName("PK_Items");

            entity.ToTable("ITEMS");

            entity.Property(e => e.ItemsId).HasColumnName("ItemsID");
            entity.Property(e => e.Category1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CATEGORY1");
            entity.Property(e => e.Itemcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ITEMCODE");
            entity.Property(e => e.Itemname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ITEMNAME");
            entity.Property(e => e.Unitprice).HasColumnName("UNITPRICE");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrdersId).HasName("PK_Orders");

            entity.ToTable("ORDERS");

            entity.Property(e => e.OrdersId).HasColumnName("OrdersID");
            entity.Property(e => e.Addressid).HasColumnName("ADDRESSID");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("DATE_");
            entity.Property(e => e.Status).HasColumnName("STATUS_");
            entity.Property(e => e.Totalprice).HasColumnName("TOTALPRICE");
            entity.Property(e => e.Userid).HasColumnName("USERID");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("FK_Orders_Users");
        });

        modelBuilder.Entity<Orderdetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailsId).HasName("PK_OrderDetails");

            entity.ToTable("ORDERDETAILS");

            entity.Property(e => e.OrderDetailsId).HasColumnName("OrderDetailsID");
            entity.Property(e => e.Amount).HasColumnName("AMOUNT");
            entity.Property(e => e.Itemid).HasColumnName("ITEMID");
            entity.Property(e => e.Linetotal).HasColumnName("LINETOTAL");
            entity.Property(e => e.Orderid).HasColumnName("ORDERID");
            entity.Property(e => e.Unitprice).HasColumnName("UNITPRICE");

            entity.HasOne(d => d.Item).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.Itemid)
                .HasConstraintName("FK_ORDERDETAILS_ITEMS");

            entity.HasOne(d => d.Order).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("FK_ORDERDETAILS_ORDERS");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentsId).HasName("PK_Payments");

            entity.ToTable("PAYMENTS");

            entity.Property(e => e.PaymentsId).HasColumnName("PaymentsID");
            entity.Property(e => e.Approvecode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("APPROVECODE");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("DATE_");
            entity.Property(e => e.Isok).HasColumnName("ISOK");
            entity.Property(e => e.Orderid).HasColumnName("ORDERID");
            entity.Property(e => e.Paymenttotal).HasColumnName("PAYMENTTOTAL");
            entity.Property(e => e.Paymenttype).HasColumnName("PAYMENTTYPE");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.Orderid)
                .HasConstraintName("FK_PAYMENTS_ORDERS");
        });

        modelBuilder.Entity<Town>(entity =>
        {
            entity.HasKey(e => e.TownsId).HasName("PK_Towns");

            entity.ToTable("TOWNS");

            entity.Property(e => e.TownsId).HasColumnName("TownsID");
            entity.Property(e => e.Cityid).HasColumnName("CITYID");
            entity.Property(e => e.Town1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TOWN");

            entity.HasOne(d => d.City).WithMany(p => p.Towns)
                .HasForeignKey(d => d.Cityid)
                .HasConstraintName("FK_TOWNS_CITIES");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.TripId).HasName("PK_Geziler");

            entity.Property(e => e.TripDate)
                .HasComment("getdate()")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.TripExplanation).IsUnicode(false);
            entity.Property(e => e.TripImg)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TripnName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Kategori).WithMany(p => p.Trips)
                .HasForeignKey(d => d.Kategoriid)
                .HasConstraintName("FK_Geziler_Kategoriler");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_Users");

            entity.ToTable("USERS");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Birthdate)
                .HasColumnType("date")
                .HasColumnName("BIRTHDATE");
            entity.Property(e => e.Createddate)
                .HasColumnType("datetime")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("EMAIL");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("GENDER");
            entity.Property(e => e.Namesurname)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("NAMESURNAME");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("PASSWORD_");
            entity.Property(e => e.Telnr1)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("TELNR1");
            entity.Property(e => e.Telnr2)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("TELNR2");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("USERNAME_");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TaxCalculationBackend.Models;

public partial class UserTaxInfoContext : DbContext
{
    public UserTaxInfoContext()
    {
    }

    public UserTaxInfoContext(DbContextOptions<UserTaxInfoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TaxInfo> TaxInfos { get; set; }

    public virtual DbSet<UserDatum> UserData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=550FEA1D28E459A;database=UserTaxInfo;integrated security=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaxInfo>(entity =>
        {
            entity.HasKey(e => e.TaxInfoId).HasName("PK__taxInfo__A134D388632987FF");

            entity.ToTable("taxInfo");

            entity.Property(e => e.TaxInfoId).HasColumnName("taxInfoId");
            entity.Property(e => e.AdvanceTaxPaid).HasColumnName("advanceTaxPaid");
            entity.Property(e => e.AssessmentYear).HasColumnName("assessmentYear");
            entity.Property(e => e.GrossTotalIncome).HasColumnName("grossTotalIncome");
            entity.Property(e => e.IncomeFromProperty).HasColumnName("incomeFromProperty");
            entity.Property(e => e.IncomeSalary).HasColumnName("incomeSalary");
            entity.Property(e => e.LongTermCapitalGains).HasColumnName("longTermCapitalGains");
            entity.Property(e => e.MunicipalTaxPaid).HasColumnName("municipalTaxPaid");
            entity.Property(e => e.NewRegime).HasColumnName("newRegime");
            entity.Property(e => e.OldRegime).HasColumnName("oldRegime");
            entity.Property(e => e.ShortTermCapitalGains).HasColumnName("shortTermCapitalGains");
            entity.Property(e => e.TotalDeduction).HasColumnName("totalDeduction");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.TaxInfos)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__taxInfo__userId__398D8EEE");
        });

        modelBuilder.Entity<UserDatum>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__userData__CB9A1CFF30D2509B");

            entity.ToTable("userData");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Age)
                .HasComputedColumnSql("(datediff(year,[dateOfBirth],getdate())-case when datepart(month,[dateOfBirth])>datepart(month,getdate()) OR datepart(month,[dateOfBirth])=datepart(month,getdate()) AND datepart(day,[dateOfBirth])>datepart(day,getdate()) then (1) else (0) end)", false)
                .HasColumnName("age");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("dateOfBirth");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("mobileNumber");
            entity.Property(e => e.PanCardNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("panCardNumber");
            entity.Property(e => e.UserAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("userAddress");
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("userName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

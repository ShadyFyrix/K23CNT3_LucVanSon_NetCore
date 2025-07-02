using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LucVanSon_231090087_Net.Models;

public partial class LucVanSon2310900087NetContext : DbContext
{
    public LucVanSon2310900087NetContext()
    {
    }

    public LucVanSon2310900087NetContext(DbContextOptions<LucVanSon2310900087NetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LvsEmployee> LvsEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-SHADY\\SQLSEVER;Database=LucVanSon_2310900087_Net;uid=ShadyFyrix;pwd=Lvson2005; MultipleActiveResultSets=True; TrustServerCertificate=True ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LvsEmployee>(entity =>
        {
            entity.HasKey(e => e.LvsEmpId).HasName("PK__LvsEmplo__3717B781E0117EF1");

            entity.ToTable("LvsEmployee");

            entity.Property(e => e.LvsEmpName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

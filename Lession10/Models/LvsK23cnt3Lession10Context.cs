using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lession10.Models;

public partial class LvsK23cnt3Lession10Context : DbContext
{
    public LvsK23cnt3Lession10Context()
    {
    }

    public LvsK23cnt3Lession10Context(DbContextOptions<LvsK23cnt3Lession10Context> options)
        : base(options)
    {
    }

    public virtual DbSet<LvsPost> LvsPosts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-SHADY\\SQLSEVER;Database=Lvs_K23CNT3_Lession10;uid=ShadyFyrix;pwd=Lvson2005; MultipleActiveResultSets=True; TrustServerCertificate=True ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LvsPost>(entity =>
        {
            entity.HasKey(e => e.Lvsid).HasName("PK__LvsPost__0AE5484C147F4007");

            entity.ToTable("Lvs_Post");

            entity.Property(e => e.LvsContent).HasColumnType("text");
            entity.Property(e => e.LvsImage)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("lvsImage");
            entity.Property(e => e.Lvsname)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MiddlewarePractice.Models;

public partial class IplogContext : DbContext
{
    public IplogContext()
    {
    }

    public IplogContext(DbContextOptions<IplogContext> options)
        : base(options)
    {
    }

    public virtual DbSet<IpLogDto> TblIpLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=KUNJ;Database=IPLog;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IpLogDto>(entity =>
        {
            entity.ToTable("tbl_IpLog");

            entity.Property(e => e.IpAddress).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
        });
        modelBuilder.HasSequence<int>("IncrementSequence");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

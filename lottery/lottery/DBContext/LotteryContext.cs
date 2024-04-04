using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace lottery.Models;

public partial class LotteryContext : DbContext
{
    public LotteryContext()
    {
    }

    public LotteryContext(DbContextOptions<LotteryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        // optionsBuilder.UseSqlServer("Server=(local); Database=lottery; Integrated Security=true; Encrypt=false;");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6CDAA6DE057");

            entity.ToTable("Product");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__Ticket__712CC607515C4476");

            entity.ToTable("Ticket");

            entity.HasOne(d => d.Product).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ticket__ProductI__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System.IO.Compression;
using Microsoft.EntityFrameworkCore;
using Turnos.Domain.Entities;

namespace Turnos.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    //para setear entidades
    public DbSet<User> Users { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Appointment>()
        .HasOne(a => a.Client)
        .WithMany(u => u.Appointments)
        .HasForeignKey(a => a.UserId)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Appointment>()
        .HasOne(a => a.Service)
        .WithMany(s => s.Appointments)
        .HasForeignKey(a => a.ServiceId)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>().OwnsOne(u => u.Email, email =>
        {
            email.Property(e => e.Value)
            .HasColumnName("Email")
            .IsRequired();
        });


    }
}
using Microsoft.EntityFrameworkCore;
using Turnos.Infrastructure.Data.Configurations;
using Turnos.Infrastructure.Data.Persistence.Configurations;
using Turnos.Infrastructure.Entities;

namespace Turnos.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    //para setear entidades
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ServiceEntity> Services { get; set; }
    public DbSet<AppointmentEntity> Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new AppointmentEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ServiceEntityConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
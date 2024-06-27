using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Context;

public class Apbd10Context : DbContext
{
    public Apbd10Context()
    {
        
    }

    public Apbd10Context(DbContextOptions<Apbd10Context> options) : base(options)
    {
        
    }

    public DbSet<Doctor> Doctors { get; set; }
    
    public DbSet<Patient> Patients { get; set; }
    
    public DbSet<Prescription> Prescriptions { get; set; }

    public DbSet<Medicament> Medicaments { get; set; }
    
    public DbSet<Prescription_Medicament> PrescriptionMedicaments { get; set; }
    
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Prescription_Medicament>()
            .HasKey(pm => new { pm.IdMedicament, pm.IdPrescription });
        
        
        modelBuilder.Entity<Patient>().HasData(new List<Patient>
        {
            new Patient {IdPatient  = 1, FirstName = "Miron", LastName = "Drychyts", Birthdate = new DateTime(1980, 1, 1) },
            new Patient {IdPatient  = 2, FirstName = "Ivan", LastName = "Drychyts", Birthdate = new DateTime(1990, 2, 2) }
        });

        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>
        {
            new Doctor {IdDoctor  = 1, FirstName = "Nikita", LastName = "Drychyts", Email = "Drychyts.lekarz@example.com" },
            new Doctor {IdDoctor  = 2, FirstName = "Chel", LastName = "Drychyts", Email = "Drychyts.lekarka@example.com" }
        });

        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>
        {
            new Medicament {IdMedicament  = 2, Name = "Paracetamol", Description = "Lek przeciwbólowy", Type = "Tabletka" },
            new Medicament {IdMedicament  = 3, Name = "Ibuprofen", Description = "Lek przeciwzapalny", Type = "Tabletka" }
        });
        
        
    }
}
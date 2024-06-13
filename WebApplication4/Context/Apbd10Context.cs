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
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Prescription_Medicament>()
            .HasKey(pm => new { pm.IdMedicament, pm.IdPrescription });
        
        /*
        modelBuilder.Entity<Patient>().HasData(new List<Patient>
        {
            new Patient {  FirstName = "Jan", LastName = "Kowalski", Birthdate = new DateTime(1980, 1, 1) },
            new Patient {  FirstName = "Anna", LastName = "Nowak", Birthdate = new DateTime(1990, 2, 2) }
        });

        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>
        {
            new Doctor {  FirstName = "Adam", LastName = "Lekarz", Email = "adam.lekarz@example.com" },
            new Doctor {  FirstName = "Ewa", LastName = "Lekarka", Email = "ewa.lekarka@example.com" }
        });

        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>
        {
            new Medicament {  Name = "Paracetamol", Description = "Lek przeciwbólowy", Type = "Tabletka" },
            new Medicament {  Name = "Ibuprofen", Description = "Lek przeciwzapalny", Type = "Tabletka" }
        });
        */
        
    }
}
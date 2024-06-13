using Microsoft.EntityFrameworkCore;
using WebApplication4.Context;
using WebApplication4.Models;
using WebApplication4.Models.DTO;

namespace WebApplication4.Repositories;

public class PrescriptionRepository : IPrescriptionRepository
{
    private readonly Apbd10Context _context;

    public PrescriptionRepository(Apbd10Context context)
    {
        _context = context;
    }

    public async Task<Prescription> AddPrescriptionAsync(NewPrescriptionRequestDto request)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var patient = await _context.Patients
                .FirstOrDefaultAsync(p => p.FirstName == request.Patient.FirstName &&
                                          p.LastName == request.Patient.LastName &&
                                          p.Birthdate == request.Patient.Birthdate);
            if (patient == null)
            {
                patient = new Patient
                {
                    FirstName = request.Patient.FirstName,
                    LastName = request.Patient.LastName,
                    Birthdate = request.Patient.Birthdate
                };
                _context.Patients.Add(patient);
                await _context.SaveChangesAsync();
            }

            var doctor = await _context.Doctors
                .FirstOrDefaultAsync(d => d.FirstName == request.Doctor.FirstName &&
                                          d.LastName == request.Doctor.LastName &&
                                          d.Email == request.Doctor.Email);
            if (doctor == null)
            {
                doctor = new Doctor
                {
                    FirstName = request.Doctor.FirstName,
                    LastName = request.Doctor.LastName,
                    Email = request.Doctor.Email
                };
                _context.Doctors.Add(doctor);
                await _context.SaveChangesAsync();
            }

            var prescription = new Prescription
            {
                Date = request.Prescription.Date,
                DueDate = request.Prescription.DueDate,
                IdPatient = patient.IdPatient,
                IdDoctor = doctor.IdDoctor,
                PrescriptionMedicaments = new List<Prescription_Medicament>()
            };

            foreach (var medDto in request.Prescription.Medicaments)
            {
                var medicament = await _context.Medicaments.FindAsync(medDto.IdMedicament);
                if (medicament == null)
                {
                    throw new Exception($"Medicament with Id {medDto.IdMedicament} does not exist.");
                }

                Prescription_Medicament pm = new Prescription_Medicament
                {
                    IdMedicament = medDto.IdMedicament,
                    Dose = medDto.Dose,
                    Details = medDto.Details
                };

                prescription.PrescriptionMedicaments.Add(pm);
            }

            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            return prescription;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw new Exception("Failed to add prescription.", ex);
        }
    }

    public async Task<Prescription> GetPrescriptionAsync(int id)
    {
        return await _context.Prescriptions
            .Include(p => p.Patient)
            .Include(p => p.Doctor)
            .Include(p => p.PrescriptionMedicaments)
            .ThenInclude(pm => pm.Medicament)
            .FirstOrDefaultAsync(p => p.IdPrescription == id);
    }
}
namespace WebApplication4.Models.DTO;

public class NewPrescriptionRequestDto
{
    public PatientDto Patient { get; set; }
    public PrescriptionDto Prescription { get; set; }
    public DoctorDto Doctor { get; set; }
}

public class PatientDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
}

public class PrescriptionDto
{
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public List<PrescriptionMedicamentDto> Medicaments { get; set; }
}

public class PrescriptionMedicamentDto
{
    public int IdMedicament { get; set; }
    public int? Dose { get; set; }
    public string Details { get; set; }
}

public class DoctorDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication4.Models;

public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public DateTime DueDate { get; set; }
    
    [Required]
    public int IdPatient { get; set; }
    
    [ForeignKey(nameof(IdPatient))]
    public Patient Patient { get; set; }
    
    [Required]
    public int IdDoctor { get; set; }
    
    [ForeignKey(nameof(IdDoctor))]
    public Doctor Doctor { get; set; }

    [JsonIgnore]
    public virtual ICollection<Prescription_Medicament> PrescriptionMedicaments { get; set; }

}
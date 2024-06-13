using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication4.Models;

public class Prescription_Medicament
{
 
    public int IdMedicament { get; set; }

    public int IdPrescription { get; set; }
    
    public int? Dose { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Details { get; set; }
    
    [JsonIgnore]
    [ForeignKey(nameof(IdPrescription))]
    public Prescription Prescription { get; set; }

    [JsonIgnore]
    [ForeignKey(nameof(IdMedicament))]
    public Medicament Medicament { get; set; }

}
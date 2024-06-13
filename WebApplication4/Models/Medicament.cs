using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication4.Models;

public class Medicament
{
    [Key]
    public int IdMedicament { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Description { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Type { get; set; }
    
    [JsonIgnore]
    public virtual ICollection<Prescription_Medicament> PrescriptionMedicaments { get; set; }
}
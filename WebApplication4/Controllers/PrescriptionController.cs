using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using WebApplication4.Models.DTO;
using WebApplication4.Repositories;

namespace WebApplication4.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class PrescriptionController : ControllerBase
{
    private readonly IPrescriptionRepository _iPrescriptionRepository;

    public PrescriptionController(IPrescriptionRepository iPrescriptionRepository)
    {
        _iPrescriptionRepository = iPrescriptionRepository;
    }
    
    [HttpPost]
    public async Task<ActionResult> AddPrescription(NewPrescriptionRequestDto request)
    {
        if (request.Prescription.DueDate < request.Prescription.Date)
        {
            return BadRequest("DueDate must be greater than or equal to Date.");
        }

        if (request.Prescription.Medicaments.Count > 10)
        {
            return BadRequest("Prescription cannot include more than 10 medicaments.");
        }

        var prescription = await _iPrescriptionRepository.AddPrescriptionAsync(request);
        return CreatedAtAction(nameof(GetPrescription), new { id = prescription.IdPrescription }, prescription);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Prescription>> GetPrescription(int id)
    {
        var prescription = await _iPrescriptionRepository.GetPrescriptionAsync(id);
        if (prescription == null)
        {
            return NotFound();
        }
        return Ok(prescription);
    }
}
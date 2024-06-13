using WebApplication4.Models;
using WebApplication4.Models.DTO;

namespace WebApplication4.Repositories;

public interface IPrescriptionRepository
{
    public Task<Prescription> AddPrescriptionAsync(NewPrescriptionRequestDto request);
    public Task<Prescription> GetPrescriptionAsync(int id);
}
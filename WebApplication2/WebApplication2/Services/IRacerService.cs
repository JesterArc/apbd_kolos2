using WebApplication2.DTOs;

namespace WebApplication2.Services;

public interface IRacerService
{
    public Task<RacerParticipationsDto?> GetRacerParticipations(int racerId);
}
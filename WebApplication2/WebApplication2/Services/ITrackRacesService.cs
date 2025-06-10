using WebApplication2.DTOs;

namespace WebApplication2.Services;

public interface ITrackRacesService
{
    public Task UpdateParticipationsAsync(TrackRacesDto trackRacesDto);
}
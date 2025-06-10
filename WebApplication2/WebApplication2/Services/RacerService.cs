using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.DTOs;
using WebApplication2.Exceptions;

namespace WebApplication2.Services;

public class RacerService : IRacerService
{
    private readonly DatabaseContext _context;

    public RacerService(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<RacerParticipationsDto?> GetRacerParticipations(int racerId)
    {
        return await _context.Racers.Where(r => r.RacerId == racerId).Select(r =>
                new RacerParticipationsDto
                {
                    RacerId = r.RacerId,
                    FirstName = r.FirstName,
                    LastName = r.LastName,
                    Participations = _context.RaceParticipations.Where(rp => rp.RacerId == racerId).Select(rp =>
                        new ParticipationDto()
                        {
                            Race = new RaceDto()
                            {
                                Name = rp.TrackRace.Race.Name,
                                Location = rp.TrackRace.Race.Location,
                                Date = rp.TrackRace.Race.Date
                            },
                            Track = new TrackDto()
                            {
                                Name = rp.TrackRace.Track.Name,
                                LengthInKm = rp.TrackRace.Track.LengthInKm
                            }
                        }).ToList()
                }).FirstOrDefaultAsync();
    }
}
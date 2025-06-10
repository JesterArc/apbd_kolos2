using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.DTOs;
using WebApplication2.Exceptions;
using WebApplication2.Models;

namespace WebApplication2.Services;

public class TrackRacesService :ITrackRacesService
{
    private readonly DatabaseContext _context;

    public TrackRacesService(DatabaseContext context)
    {
        _context = context;
    }
    public async Task UpdateParticipationsAsync(TrackRacesDto trackRacesDto)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            if (await _context.Races.FirstOrDefaultAsync(r => r.Name == trackRacesDto.RaceName) == null)
            {
                throw new NotFoundException("Race not found");
            }

            if (await _context.Tracks.FirstOrDefaultAsync(t => t.Name == trackRacesDto.TrackName) == null)
            {
                throw new NotFoundException("Track not found");
            }

            if (await _context.TrackRaces.FirstOrDefaultAsync(tr =>
                    tr.Track.Name == trackRacesDto.TrackName && tr.Race.Name == trackRacesDto.RaceName) != null)
            {
                throw new ExistsException("Track Race already Exists");
            }

            var track = await _context.Tracks.FirstOrDefaultAsync(t => t.Name == trackRacesDto.TrackName);
            var race = await _context.Races.FirstOrDefaultAsync(r => r.Name == trackRacesDto.RaceName);
            var max = await _context.TrackRaces.Select(tr => tr.TrackRaceId).MaxAsync();
            _context.TrackRaces.AddAsync(new TrackRace()
            {
                TrackRaceId = max + 1,
                TrackId = track.TrackId,
                RaceId = race.RaceId
            });
            await _context.SaveChangesAsync();
            foreach (var participation in trackRacesDto.Participations)
            {
                if (await _context.Racers.FirstOrDefaultAsync(r => r.RacerId == participation.RacerId) == null)
                {
                    throw new NotFoundException("Racer not found");
                }

                _context.RaceParticipations.AddAsync(new RaceParticipation()
                {
                    RacerId = participation.RacerId,
                    FinishTimeInSeconds = participation.FinishTimeInSeconds,
                    TrackRace = _context.TrackRaces.First(tr => tr.TrackRaceId == max + 1),
                    Position = participation.Position,
                });
                await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            transaction.RollbackAsync();
            throw;
        }
    }
}
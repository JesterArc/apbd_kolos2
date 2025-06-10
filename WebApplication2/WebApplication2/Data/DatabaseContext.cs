using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
namespace WebApplication2.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Race> Races { get; set; }
    public DbSet<Track> Tracks { get; set; }
    public DbSet<Racer> Racers { get; set; }
    public DbSet<TrackRace> TrackRaces { get; set; }
    public DbSet<RaceParticipation> RaceParticipations { get; set; }
    protected DatabaseContext()
    {
        
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Race>().HasData(new List<Race>()
        {
            new Race() {RaceId = 1, Date = DateTime.Parse("2026-09-01"), Name = "200CC", Location = "Mushroom Kingdom"},
            new Race() {RaceId = 2, Date = DateTime.Parse("2026-09-02"), Name = "300CC", Location = "Florida, USA"}
        });
        
        modelBuilder.Entity<Track>().HasData(new List<Track>()
        {
            new Track() { TrackId = 1, LengthInKm = 100.52, Name = "Rainbow Road" },
            new Track() { TrackId = 2, LengthInKm = 212.00, Name = "Coconut Mall" },
            new Track() { TrackId = 3, LengthInKm = 555.12, Name = "Some Other Track" }
        });

        modelBuilder.Entity<Racer>().HasData(new List<Racer>()
        {
            new Racer() { RacerId = 1, FirstName = "Mario", LastName = "Mario" },
            new Racer() { RacerId = 2, FirstName = "Luigi", LastName = "Mario" },
            new Racer() { RacerId = 3, FirstName = "Sebasitian", LastName = "Vettel" }
        });

        modelBuilder.Entity<TrackRace>().HasData(new List<TrackRace>()
        {
            new TrackRace() { TrackRaceId = 1, RaceId = 1, TrackId = 1, Laps = 5 },
            new TrackRace() { TrackRaceId = 2, RaceId = 1, TrackId = 2, Laps = 7 },
            new TrackRace() { TrackRaceId = 3, RaceId = 2, TrackId = 3, Laps = 10 }
        });

        modelBuilder.Entity<RaceParticipation>().HasData(new List<RaceParticipation>()
        {
            new RaceParticipation() { TrackRaceId = 1, RacerId = 1, Position = 1, FinishTimeInSeconds = 50000 },
            new RaceParticipation() { TrackRaceId = 1, RacerId = 2, Position = 2, FinishTimeInSeconds = 60000 },
            new RaceParticipation() { TrackRaceId = 2, RacerId = 1, Position = 2, FinishTimeInSeconds = 44444 },
            new RaceParticipation() { TrackRaceId = 2, RacerId = 2, Position = 1, FinishTimeInSeconds = 33333 },
            new RaceParticipation() { TrackRaceId = 3, RacerId = 3, Position = 1, FinishTimeInSeconds = 10000 }
        });
    }
}
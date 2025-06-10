using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models;

[Table("Race")]
public class Race
{
    [Key]
    public int RaceId { get; set; }
    [MaxLength(50)]
    public string Name { get; set; } = null!;
    [MaxLength(100)]
    public string Location { get; set; } = null!;
    public required DateTime Date { get; set; }
    
    public ICollection<TrackRace> TrackRaces { get; set; } = null!;
}
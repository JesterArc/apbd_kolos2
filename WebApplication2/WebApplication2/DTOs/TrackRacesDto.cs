namespace WebApplication2.DTOs;

public class TrackRacesDto
{
    public string RaceName { get; set; } = null!;
    public string TrackName { get; set; } = null!; 
    public List<SimplerParticipationDto> Participations { get; set; } = null!;
}

public class SimplerParticipationDto
{
    public int  RacerId { get; set; }
    public int Position { get; set; }
    public int FinishTimeInSeconds { get; set; }
}
using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTOs;
using WebApplication2.Exceptions;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

[ApiController]
[Route("api/track-races")]
public class TrackRacesController : ControllerBase
{
    private readonly ITrackRacesService _trackRacesService;

    public TrackRacesController(ITrackRacesService trackRacesService)
    {
        _trackRacesService = trackRacesService;
    }
    
    [HttpPost("participants")]
    public async Task<IActionResult> UpdateParticipations([FromBody] TrackRacesDto trackRaces)
    {
        try
        {
            await _trackRacesService.UpdateParticipationsAsync(trackRaces);
            return Accepted();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ExistsException e)
        {
            return Conflict(e.Message);
        }
    }
}
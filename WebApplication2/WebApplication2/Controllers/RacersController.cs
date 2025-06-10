using Microsoft.AspNetCore.Mvc;
using WebApplication2.Exceptions;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RacersController : ControllerBase
{
    private readonly IRacerService _racerService;

    public RacersController(IRacerService racerService)
    {
        _racerService = racerService;
    }

    [HttpGet("{id}/participations")]
    public async Task<IActionResult> GetRacerParticipation(int id)
    {
        var participations = await _racerService.GetRacerParticipations(id);
        if (participations == null)
        {
            return NotFound("Racer not found");
        }
        else
        {
            return Ok(participations);
        }
    }
}
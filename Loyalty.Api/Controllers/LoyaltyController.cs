using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Loyalty.Api.Controllers;

[ApiController]
[Route("api/loyalty")]
public class LoyaltyController : ControllerBase
{
    private readonly ILoyaltyScoreService _service;

    public LoyaltyController(ILoyaltyScoreService service)
    {
        _service = service;
    }

    [HttpPost("calculate")]
    public async Task<IActionResult> Calculate(
        CalculateScoreRequest request,
        CancellationToken cancellationToken)
    {
        var result = await _service.CalculateAsync(request, cancellationToken);
        return Ok(result);
    }
}
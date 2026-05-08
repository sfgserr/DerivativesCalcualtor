using Asp.Versioning;
using DerivativesCalculator.Core.UseCases.Differentiate;
using Microsoft.AspNetCore.Mvc;

namespace DerivativesCalculator.WebApi.Controllers;

[Route("api/v{version:apiVersion}/differentiate")]
[ApiVersion("1.0")]
[ApiController]
public class DifferentiateController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Index([FromServices] DifferentiateUseCase useCase, [FromHeader(Name = "Expression")]string input)
    {
        var result = await useCase.Execute(new DifferentiateCommand(input));
        return Ok(result);
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stocky.Shared.Dtos;
using Stocky.WebApi.Application.ReportData.Commands;

namespace Stocky.WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ReportController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ReportSummaryDto>> GetReportSummary([FromQuery] GetReportCommand getReportCommand)
    {
        return Ok(await mediator.Send(getReportCommand));
    }
}
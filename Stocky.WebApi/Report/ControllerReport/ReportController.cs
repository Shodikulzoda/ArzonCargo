using Microsoft.AspNetCore.Mvc;
using Stocky.Shared.Dtos;
using Stocky.WebApi.Report.ServiceReport.Interface;

namespace Stocky.WebApi.Report.ControllerReport;

[ApiController]
[Route("api/reports")]
public class ReportController(IReportService service) : ControllerBase
{
    [HttpGet("summary")]
    public async Task<ActionResult<ReportSummaryDto>> GetReportSummary([FromQuery] DateTime start,
        [FromQuery] DateTime end)
    {
        var summary = await service.GetSummaryAsync(start, end);
        return Ok(summary);
    }
}
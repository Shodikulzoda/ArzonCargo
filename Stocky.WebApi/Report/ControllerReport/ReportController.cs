using Microsoft.AspNetCore.Mvc;
using Stocky.WebApi.Report.Dtos;
using Stocky.WebApi.Report.ServiceReport.Interface;

namespace Stocky.WebApi.Report.ControllerReport;

[ApiController]
[Route("api/reports")]
public class ReportController : ControllerBase
{
    private readonly IReportService _service;

    public ReportController(IReportService service)
    {
        _service = service;
    }

    [HttpGet("summary")]
    public async Task<ActionResult<ReportSummaryDto>> GetReportSummary([FromQuery] DateTime start,
        [FromQuery] DateTime end)
    {
        var summary = await _service.GetSummaryAsync(start, end);
        return Ok(summary);
    }
}
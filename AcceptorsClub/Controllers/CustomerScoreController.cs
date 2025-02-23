using AcceptorsClub.Application;
using AcceptorsClub.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcceptorsClub.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class CustomerScoreController : ControllerBase
{
    private readonly IMediator _mediator;
    public CustomerScoreController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("CustomerScoreList")]
    public async Task<IActionResult> CustomerScoreList([FromQuery] string nationalCode)
    {
        var result = await _mediator.Send(new CustomerScoreQuery(nationalCode));
        return Ok(result);
    }

    [HttpGet("SumCustomerScore")]
    public async Task<IActionResult> SumCustomerScore([FromQuery] string nationalCode)
    {
        var result = await _mediator.Send(new SumCustomerScoreQuery(nationalCode));
        return Ok(result);
    }

    /// <summary>
    /// OperationType is a enum value 0 means charge+ and 1 means spend-
    /// </summary>
    [HttpPost("AddCustomerScore")]
    public async Task<IActionResult> AddCustomerScore([FromBody] CustomerScoreCommand customerScore)
    {
        var result = await _mediator.Send(customerScore);
        return Ok(result);
    }
    [HttpGet("GetScorePlan")]
    public async Task<IActionResult> GetScorePlan()
    {
        var result = await _mediator.Send(new GetALLScorePlanQuery());
        return Ok(result);
    }
    [HttpGet("GetActiveLotteries")]
    public async Task<IActionResult> GetActiveLotteries()
    {
        var result = await _mediator.Send(new GetLotteryListQuery());
        return Ok(result);
    }
    [HttpGet("GetActiveCompetitions")]
    public async Task<IActionResult> GetActiveCompetitions()
    {
        var result = await _mediator.Send(new GetCompetitionQuery());
        return Ok(result);
    }
}

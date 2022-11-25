using Confab.Modules.Tickets.Core.DTO;
using Confab.Modules.Tickets.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Confab.Modules.Tickets.Api.Controllers;

internal class SalesController : BaseController
{
    private readonly ITicketSaleService _ticketSaleService;
    private const string Policy = "tickets";

    public SalesController(ITicketSaleService ticketSaleService)
    {
        _ticketSaleService = ticketSaleService;
    }

    [HttpGet("conferences/{conferenceId}/current")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<TicketSaleInfoDto>> GetCurrent(Guid conferenceId)
        => OkOrNotFound(await _ticketSaleService.GetCurrentAsync(conferenceId));

    [HttpGet("conferences/{conferenceId}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<TicketSaleInfoDto>>> GetAll(Guid conferenceId)
        => OkOrNotFound(await _ticketSaleService.GetAllAsync(conferenceId));

    [Authorize(Policy)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [HttpPost("conferences/{conferenceId}")]
    public async Task<ActionResult> Post(Guid conferenceId, TicketSaleDto dto)
    {
        dto.ConferenceId = conferenceId;
        await _ticketSaleService.AddAsync(dto);
        return NoContent();
    }
}
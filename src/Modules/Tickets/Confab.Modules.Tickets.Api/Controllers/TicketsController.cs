using Confab.Modules.Tickets.Core.DTO;
using Confab.Modules.Tickets.Core.Services;
using Confab.Shared.Abstractions.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Confab.Modules.Tickets.Api.Controllers;

[Authorize]
internal class TicketsController : BaseController
{
    private readonly ITicketService _ticketService;
    private readonly IContext _context;

    public TicketsController(ITicketService ticketService, IContext context)
    {
        _ticketService = ticketService;
        _context = context;
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public async Task<ActionResult<IReadOnlyList<TicketDto>>> Get()
        => Ok(await _ticketService.GetForUserAsync(_context.Identity.Id));

    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [HttpPost("conferences/{conferenceId}/purchase")]
    public async Task<ActionResult> Purchase(Guid conferenceId)
    {
        await _ticketService.PurchaseAsync(conferenceId, _context.Identity.Id);
        return NoContent();
    }
}
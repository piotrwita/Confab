﻿using Confab.Modules.Speakers.Core.DTO;
using Confab.Modules.Speakers.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Confab.Modules.Speakers.Api.Controllers;

[Authorize(Policy = Policy)]
internal class SpeakersController : BaseController
{
    private const string Policy = "speakers";

    private readonly ISpeakerService _speakerService;

    public SpeakersController(ISpeakerService speakerService)
    {
        _speakerService = speakerService;
    }

    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    public async Task<ActionResult<SpeakerDto>> Get(Guid id)
        => OkOrNotFound(await _speakerService.GetAsync(id));

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IReadOnlyList<SpeakerDto>>> GetAllAsync()
        => Ok(await _speakerService.GetAllAsync());

    [HttpPost]
    public async Task<ActionResult> AddAsync(SpeakerDto dto)
    {
        await _speakerService.AddAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = dto.Id }, null);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateAsync(Guid id, SpeakerDto dto)
    {
        dto.Id = id;
        await _speakerService.UpdateAsync(dto);
        return NoContent();
    } 
}
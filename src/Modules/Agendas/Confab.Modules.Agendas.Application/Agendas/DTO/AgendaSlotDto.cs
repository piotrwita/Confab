﻿namespace Confab.Modules.Agendas.Application.Agendas.DTO;

public abstract class AgendaSlotDto
{
    public Guid Id { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public string Type { get; set; }
}

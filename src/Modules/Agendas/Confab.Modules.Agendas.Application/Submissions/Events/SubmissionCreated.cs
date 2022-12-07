using Confab.Shared.Abstractions.Events;

namespace Confab.Modules.Agendas.Application.Events;

public record SubmissionCreated(Guid Id) : IEvent;

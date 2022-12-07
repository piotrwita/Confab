using Confab.Shared.Abstractions.Events;

namespace Confab.Modules.Agendas.Application.Events;

public record SubmissionApproved(Guid Id) : IEvent;
using Confab.Shared.Abstractions.Exceptions;

namespace Confab.Modules.Agendas.Domain.Submissions.Exceptions;

internal class InvalidSubmissionLevelException : ConfabException
{
    public Guid SubmissionId { get; }

    public InvalidSubmissionLevelException(Guid submissionId) : base($"Submission with ID: {submissionId} defines invald level.")
        => SubmissionId = submissionId;
}

﻿using Confab.Shared.Abstractions.Exceptions;

namespace Confab.Modules.Agendas.Application.Submissions.Exceptions;

internal class InvalidSpeakersNumberException : ConfabException
{
    public Guid SubmissionId { get; }

    public InvalidSpeakersNumberException(Guid submissionId) : base($"Submission with ID: {submissionId} has invalid number of speakers.")
        => SubmissionId = submissionId;
}

using System.Net;

namespace Confab.Shared.Abstraction.Exceptions;

public record ExceptionResponse(object Response, HttpStatusCode StatusCode);
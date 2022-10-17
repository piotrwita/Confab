using Confab.Shared.Abstraction;

namespace Confab.Shared.Infrastructure.Time;

internal class UtcClock : IClock
{
    public DateTime CurrentDate() => DateTime.UtcNow;
}

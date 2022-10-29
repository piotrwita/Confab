using Confab.Modules.Speakers.Core.Entities;

namespace Confab.Modules.Speakers.Core.Repositories;

internal class InMemorySpeakerRepository : ISpeakerRepository
{
    // Not thread-safe, use Concurrent collections
    private readonly List<Speaker> _speakers = new();

    public Task<Speaker> GetAsync(Guid id) => Task.FromResult(_speakers.SingleOrDefault(x => x.Id == id));

    public async Task<IReadOnlyList<Speaker>> GetAllAsync()
    {
        await Task.CompletedTask;
        return _speakers;
    }

    public Task<bool> ExistsAsync(Guid id) => Task.FromResult(_speakers.Any(x => x.Id == id));

    public Task AddAsync(Speaker speaker)
    {
        _speakers.Add(speaker);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Speaker speaker)
    {
        return Task.CompletedTask;
    }
}

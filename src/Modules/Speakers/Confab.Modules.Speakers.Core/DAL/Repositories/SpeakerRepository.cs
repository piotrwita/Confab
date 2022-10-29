using Confab.Modules.Speakers.Core.Entities;
using Confab.Modules.Speakers.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Confab.Modules.Speakers.Core.DAL.Repositories;

internal class SpeakerRepository : ISpeakerRepository
{
    private readonly SpeakersDbContext _context;
    private readonly DbSet<Speaker> _speakers;

    public SpeakerRepository(SpeakersDbContext context)
    {
        _context = context;
        _speakers = context.Speakers;
    }

    public async Task<Speaker> GetAsync(Guid id)
        => await _speakers.SingleOrDefaultAsync(x => x.Id == id);

    public async Task<IReadOnlyList<Speaker>> GetAllAsync() 
        => await _speakers.ToListAsync();

    public async Task<bool> ExistsAsync(Guid id)
        => await _speakers.AnyAsync(x => x.Id == id);

    public async Task AddAsync(Speaker speaker)
    {
        await _speakers.AddAsync(speaker);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Speaker speaker)
    {
        _speakers.Update(speaker);
        await _context.SaveChangesAsync();
    }


}

using Confab.Modules.Speakers.Core.DTO;

namespace Confab.Modules.Speakers.Core.Services;

internal interface ISpeakerService
{
    Task<SpeakerDto> GetAsync(Guid id);
    Task<IEnumerable<SpeakerDto>> GetAllAsync();
    Task AddAsync(SpeakerDto dto);
    Task UpdateAsync(SpeakerDto dto); 
}

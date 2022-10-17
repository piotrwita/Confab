using Confab.Modules.Conferences.Core.DTO;

namespace Confab.Modules.Conferences.Core.Services;

internal interface IHostService
{
    Task<HostDetailsDto> GetAsync(Guid id);
    Task<IReadOnlyList<HostDto>> GetAllAsync();
    Task AddAsync(HostDto dto);
    Task UpdateAsync(HostDetailsDto dto);
    Task DeleteAsync(Guid id);
}

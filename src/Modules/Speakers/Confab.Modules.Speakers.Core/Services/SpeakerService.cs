using Confab.Modules.Speakers.Core.DTO;
using Confab.Modules.Speakers.Core.Entities;
using Confab.Modules.Speakers.Core.Events;
using Confab.Modules.Speakers.Core.Exceptions;
using Confab.Modules.Speakers.Core.Mapping;
using Confab.Modules.Speakers.Core.Repositories;
using Confab.Shared.Abstractions.Messaging;

namespace Confab.Modules.Speakers.Core.Services;

internal class SpeakerService : ISpeakerService
{
    private readonly ISpeakerRepository _speakerRepository;
    private readonly IMessageBroker _messageBroker;

    public SpeakerService(ISpeakerRepository speakerRepository, IMessageBroker messageBroker)
    {
        _speakerRepository = speakerRepository;
        _messageBroker = messageBroker;
    }

    public async Task<SpeakerDto> GetAsync(Guid id)
    {
        var speaker = await _speakerRepository.GetAsync(id); 

        return speaker?.AsDto();
    }

    public async Task<IEnumerable<SpeakerDto>> GetAllAsync()
    {
        var speakers = await _speakerRepository.GetAllAsync();

        return speakers?.Select(x => x.AsDto());
    }

    public async Task AddAsync(SpeakerDto dto)
    {
        var exists = await _speakerRepository.ExistsAsync(dto.Id);

        if (exists)
        {
            throw new SpeakerAlreadyExistsException(dto.Id);
        }

        await _speakerRepository.AddAsync(dto.AsEntity());
        await _messageBroker.PublishAsync(new SpeakerCreated(dto.Id, dto.FullName));
    }

    public async Task UpdateAsync(SpeakerDto dto)
    {
        var exists = await _speakerRepository.ExistsAsync(dto.Id);

        if (!exists)
        {
            throw new SpeakerNotFoundException(dto.Id);
        }

        await _speakerRepository.UpdateAsync(dto.AsEntity()); 
    } 
}
using Confab.Modules.Speakers.Core.DTO;
using Confab.Modules.Speakers.Core.Entities;

namespace Confab.Modules.Speakers.Core.Mapping;
internal static class Extensions
{
    public static SpeakerDto AsDto(this Speaker speaker)
        => new()
        {
            Id = speaker.Id,
            Email = speaker.Email,
            FullName = speaker.FullName,
            Bio = speaker.Bio,
            AvatarUrl = speaker.AvatarUrl
        };

    public static Speaker AsEntity(this SpeakerDto dto)
        => new()
        {
            Id = dto.Id,
            Email = dto.Email,
            FullName = dto.FullName,
            Bio = dto.Bio,
            AvatarUrl = dto.AvatarUrl
        };
}

using Confab.Modules.Agendas.Domain.Submissions.Entities;
using Confab.Shared.Abstractions.Kernel.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confab.Modules.Agendas.Infrastructure.EF;

internal class SpeakerConfiguration : IEntityTypeConfiguration<Speaker>
{
    public void Configure(EntityTypeBuilder<Speaker> builder)
    {
        //jawne wskazanie klucza
        builder.HasKey(x => x.Id);

        //jak ten klucz ma byc konwertowany (konwert z aggid na guida a potem z guid na aggid)
        builder
            .Property(x => x.Id)
            .HasConversion(x => x.Value, x => new AggregateId(x));

        //wlaczamy optimistic locking - jezel bedziemy mieli wspolbiezny dostep i nie bedzie zgadzala sie wersja
        //updatowanego agreatu to zmiany beda odrzucone
        builder
            .Property(x => x.Version)
            .IsConcurrencyToken();
    }
}

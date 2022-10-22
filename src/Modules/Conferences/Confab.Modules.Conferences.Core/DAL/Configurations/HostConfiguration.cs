using Confab.Modules.Conferences.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confab.Modules.Conferences.Core.DAL.Configurations;

internal class HostConfiguration : IEntityTypeConfiguration<Host>
{
    //ciekawostka... jezeli pole klucza obcego jest przykladowo nazwa + Id
    //np HostId ef ogarnie ze to klucz 
    public void Configure(EntityTypeBuilder<Host> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
    }
}
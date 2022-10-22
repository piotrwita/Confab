using Confab.Modules.Conferences.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confab.Modules.Conferences.Core.DAL.Configurations;

//punkt styku miedzy app a sql - mozna tu ustalac wszelkie opcje dla obiektow
internal class ConferenceConfiguration : IEntityTypeConfiguration<Conference>
{
    public void Configure(EntityTypeBuilder<Conference> builder)
    {
    }
}

﻿using Confab.Modules.Agendas.Domain.Submissions.Entities;
using Confab.Shared.Abstractions.Kernel.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confab.Modules.Agendas.Infrastructure.EF;

internal class SubmissionConfiguration : IEntityTypeConfiguration<Submission>
{
    public void Configure(EntityTypeBuilder<Submission> builder)
    { 
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .HasConversion(x => x.Value, x => new AggregateId(x));

        builder
            .Property(x => x.ConferenceId)
            .HasConversion(x => x.Value, x => new ConferenceId(x));

        builder
            .Property(x => x.Tags)
            .HasConversion(x => string.Join(',', x), x => x.Split(',', StringSplitOptions.None));

        builder
            .Property(x => x.Version)
            .IsConcurrencyToken();

        //sledzenie zmian na wewnwtrznej kolekcji
        //sledzenie zmian na liscie stringow / tagow
        //porownanie dwoch kolekcji stringow
        builder
            .Property(x => x.Tags).Metadata.SetValueComparer(
                new ValueComparer<IEnumerable<string>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, next) => HashCode.Combine(a, next.GetHashCode())),
                    c => c.ToArray()));

        //konfiguracja many to many speakers i submissions
        //wystarzcy ze speakers posiada kolekcje submissions i na odwrot
    }
}

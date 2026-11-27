using Domain.Helpers;
using Emails.Write.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Emails.Write.Api.Infrastructure.Persistence.Config;

public sealed class EmailMessageConfiguration : IEntityTypeConfiguration<EmailMessage>
{
    public void Configure(EntityTypeBuilder<EmailMessage> builder)
    {
        builder.ToTable("email_messages");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.ScheduledAt).HasColumnName("scheduled_at").IsRequired();
        builder.Property(x => x.Status).HasColumnName("status").HasConversion<short>().IsRequired();
        builder.Property(x => x.Attempts).HasColumnName("attempts").IsRequired();
        builder.Property(x => x.LastError).HasColumnName("last_error");
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
        builder.Property(x => x.UpdatedAt).HasColumnName("updated_at").IsRequired();
        builder.Property(x => x.LockedBy).HasColumnName("locked_by").HasMaxLength(64);
        builder.Property(x => x.LockedUntil).HasColumnName("locked_until");

        // xmin из PostgreSQL — идеально для воркера (optimistic concurrency без доп. столбца)
        builder.Property(x => x.Version).IsRowVersion().HasColumnName("xmin");

        builder.OwnsOne(x => x.Recipient, recipientBuilder =>
        {
            recipientBuilder.Property(p => p.Value)
                .HasColumnName("recipient")
                .HasMaxLength(DomainConstValues.EMAIL_ADDRESS_MAX_LENGTH)
                .IsRequired();
        });

        builder.OwnsOne(x => x.Body, bodyBuilder =>
        {
            bodyBuilder.Property(p => p.Value)
                .HasColumnName("body")
                .HasMaxLength(DomainConstValues.EMAIL_BODY_MAX_LENGTH)
                .IsRequired();
        });
    }
}

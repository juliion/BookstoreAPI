using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infrastucture.EntityTypeConfigurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(author => author.Id);
        builder.HasIndex(author => author.Id)
            .IsUnique();
        builder.Property(author => author.Name)
            .IsRequired()
            .HasMaxLength(250);
    }
}


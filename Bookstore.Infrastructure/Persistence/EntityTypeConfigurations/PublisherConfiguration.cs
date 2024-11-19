using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Bookstore.Domain.Entities;

namespace Bookstore.Infrastucture.EntityTypeConfigurations;

public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.HasKey(pub => pub.Id);
        builder.HasIndex(pub => pub.Id)
            .IsUnique();
        builder.Property(pub => pub.Name)
            .IsRequired()
            .HasMaxLength(250);
    }
}
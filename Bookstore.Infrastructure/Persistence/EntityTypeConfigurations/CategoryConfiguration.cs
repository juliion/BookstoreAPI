using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Bookstore.Domain.Entities;

namespace Bookstore.Infrastucture.EntityTypeConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(cat => cat.Id);
        builder.HasIndex(cat => cat.Id)
            .IsUnique();
        builder.Property(cat => cat.Name)
            .IsRequired()
            .HasMaxLength(250);
    }
}

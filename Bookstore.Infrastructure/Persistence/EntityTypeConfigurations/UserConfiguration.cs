using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastucture.EntityTypeConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(user => user.Name)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(user => user.Surname)
            .HasMaxLength(100)
            .IsRequired();
        builder.HasMany(user => user.UserRefreshTokens)
            .WithOne(rt => rt.User)
            .HasForeignKey(rt => rt.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}

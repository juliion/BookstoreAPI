using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.Persistence.EntityTypeConfigurations;

public class UserRefreshTokenConfiguration : IEntityTypeConfiguration<UserRefreshToken>
{
    public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
    {
        builder.HasKey(rt => rt.Token);
        builder.Property(rt => rt.Token).IsRequired();
        builder.Property(rt => rt.UserId).IsRequired();
        builder.Property(rt => rt.Expires).IsRequired();
    }
}

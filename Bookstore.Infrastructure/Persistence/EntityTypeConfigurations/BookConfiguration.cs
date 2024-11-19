using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Bookstore.Domain.Entities;
using System.Reflection.Metadata;

namespace Bookstore.Infrastucture.EntityTypeConfigurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(book => book.Id);
        builder.HasIndex(book => book.Id)
            .IsUnique();
        builder.Property(book => book.Title)
            .IsRequired()
            .HasMaxLength(250);
        builder.Property(book => book.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        builder.Property(book => book.StockQuantity)
            .IsRequired();
        builder.Property(book => book.PublicationDate)
            .IsRequired();
        builder.Property(book => book.Language)
            .IsRequired();
        builder.HasOne(book => book.Author)
        .WithMany(author => author.Books)
            .HasForeignKey(book => book.AuthorId);
        builder.HasOne(book => book.Publisher)
            .WithMany(pub => pub.Books)
            .HasForeignKey(book => book.PublisherId);
    }
}

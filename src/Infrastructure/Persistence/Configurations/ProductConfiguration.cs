using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products")
                .HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier");

            builder.Property(o => o.Name)
                .HasColumnName("Name")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(o => o.CategoryId)
                .HasColumnName("CategoryId")
                .IsRequired();

            builder.Property(o => o.Price)
                .HasColumnName("Price")
                .HasColumnType("decimal(18,4)")
                .IsRequired();

            builder.Property(o => o.Quantity)
                .HasColumnName("Quantity")
                .IsRequired();

            builder
                .HasOne(o => o.Category)
                .WithMany(o => o.Products)
                .HasForeignKey(o => o.CategoryId);
        }
    }
}

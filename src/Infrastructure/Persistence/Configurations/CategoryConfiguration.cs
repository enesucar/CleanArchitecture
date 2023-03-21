using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories")
                .HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier");

            builder.Property(o => o.Name)
               .HasColumnName("Name")
               .HasMaxLength(250)
               .IsRequired();
        }
    }
}

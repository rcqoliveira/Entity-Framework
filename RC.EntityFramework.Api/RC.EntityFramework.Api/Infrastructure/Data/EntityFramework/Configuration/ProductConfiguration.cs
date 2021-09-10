using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RC.EntityFramework.Api.Core.Domains.Entitie;

namespace RC.EntityFramework.Api.Infrastructure.Data.EntityFramework
{
    public class ProductConfiguration : BaseConfiguration, IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product", Schema);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Price).HasColumnName(@"Price").HasColumnType("numeric").IsRequired();
            builder.Property(x => x.ProductName).HasColumnName(@"ProductName").HasColumnType("varchar(60)").IsRequired().IsUnicode(false).HasMaxLength(60);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("varchar(200)").IsRequired().IsUnicode(false).HasMaxLength(200);
        }
    }
}
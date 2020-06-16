using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class CompanyProductConfiguration : IEntityTypeConfiguration<CompanyProduct>
    {
        public void Configure(EntityTypeBuilder<CompanyProduct> builder)
        {
            builder.ToTable("CompanyProducts");

            builder.HasIndex(a => a.Id)
                .IsUnique();

            builder.HasOne(a => a.Company)
                .WithMany(a => a.CompanyProducts);
            builder.HasOne(a => a.Product);
        }
    }
}
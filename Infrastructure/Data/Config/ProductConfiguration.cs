using core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product> //used when i create a table that has column like name colum and i want it to be required
    {
        //i can her add properties of coumns in a table
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p=>p.Id).IsRequired();
            builder.Property(p=>p.Name).IsRequired().HasMaxLength(100); 
            builder.Property(p=>p.Description).IsRequired().HasMaxLength(180); 
            builder.Property(p=>p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p=>p.PictureUrl).IsRequired();
            //make relationship

            builder.HasOne(b=>b.ProductBrand).WithMany().HasForeignKey(p=>p.ProductBrandId);
            builder.HasOne(b=>b.ProductType).WithMany().HasForeignKey(p=>p.ProductTypeId);
        }
    }
}
using Contact.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Data.Configurations
{
    public class OwnerConfiguration : IEntityTypeConfiguration<OwnerModel>
    {
        public void Configure(EntityTypeBuilder<OwnerModel> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).UseIdentityColumn();
            builder.Property(m => m.Name).IsRequired();
            builder.Property(m => m.PhoneNumber).IsRequired();
            builder.Property(m => m.Address).IsRequired();
            builder.Property(m => m.Email).IsRequired();

            builder.ToTable("Owners");
        }
    }
}

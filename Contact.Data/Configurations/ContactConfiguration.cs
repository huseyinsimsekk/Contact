using Contact.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Data.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<ContactModel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ContactModel> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).UseIdentityColumn();
            builder.Property(m => m.Name).IsRequired();
            builder.Property(m => m.OwnerId).IsRequired();
            builder.Property(m => m.PhoneNumber).IsRequired();
            builder.Property(m => m.Address).IsRequired();
            builder.Property(m => m.Email).IsRequired();
           
            builder.ToTable("Contacts");
        }
    }
}

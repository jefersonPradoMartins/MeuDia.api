using MeuDia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuDia.Infra.Mapping
{
    public class TagMap : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(t => t.TagId).ValueGeneratedOnAdd();
            builder.HasKey(t => t.TagId);
            builder.HasOne(x => x.Color).WithMany(x => x.Tags);
        }
    }
}

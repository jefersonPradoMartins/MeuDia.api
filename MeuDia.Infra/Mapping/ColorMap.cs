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
    public class ColorMap : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.Property(t => t.ColorId).ValueGeneratedOnAdd();
            builder.HasKey(t => t.ColorId);

            builder.HasDiscriminator(t => t.Discriminator);
        }
    }
}


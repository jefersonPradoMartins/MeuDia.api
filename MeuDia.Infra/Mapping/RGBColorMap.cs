using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeuDia.Domain.Entities;

namespace MeuDia.Infra.Mapping
{
    internal class RGBColorMap : IEntityTypeConfiguration<RGBColor>
    {
        public void Configure(EntityTypeBuilder<RGBColor> builder)
        {

        }
    }
}

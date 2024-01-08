using MeuDia.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuDia.Infra.Mapping
{
    internal class HexColorMap : IEntityTypeConfiguration<HexColor>
    {
        public void Configure(EntityTypeBuilder<HexColor> builder)
        {

        }
    }
}

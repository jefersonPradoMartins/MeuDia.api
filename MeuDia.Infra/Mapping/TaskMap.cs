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
    public class TaskMap : IEntityTypeConfiguration<Domain.Entities.Task>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Task> builder)
        {
            builder.Property(i => i.TaskId).ValueGeneratedOnAdd();
            builder.HasKey(table => new { table.TaskId });
            builder.HasMany(t => t.Tags).WithMany(t => t.Tasks).UsingEntity(typeof(TaskTag),
                l => l.HasOne(typeof(Tag)).WithMany().HasForeignKey("TagId")
                .HasPrincipalKey(nameof(Tag.TagId)),
                r => r.HasOne(typeof(Domain.Entities.Task)).WithMany().HasForeignKey("TaskId").HasPrincipalKey(nameof(Domain.Entities.Task.TaskId)),
                j => j.HasKey("TagId", "TaskId"));
        }
    }
}

using MeuDia.Domain.Entities;
using MeuDia.Services.DTO.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuDia.Services.Service.Interface
{
    public interface ITagService
    {
        System.Threading.Tasks.Task CreateAsync(CreateTag tag);
        System.Threading.Tasks.Task DeleteAsync(int tagId);
        System.Threading.Tasks.Task UpdateAsync(Tag tag);
        System.Threading.Tasks.Task<Tag> GetByIdAsync(int tagId);
    }
}

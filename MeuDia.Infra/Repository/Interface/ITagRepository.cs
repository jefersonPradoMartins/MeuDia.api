
using MeuDia.Domain.Entities;

namespace MeuDia.Infra.Repository.Interface
{
    public interface ITagRepository
    {
        System.Threading.Tasks.Task CreateAsync(Tag tag);
        System.Threading.Tasks.Task DeleteAsync(int tagId);
        System.Threading.Tasks.Task UpdateAsync(Tag tag);
        System.Threading.Tasks.Task<Tag> GetByIdAsync(int tagId);
    }
}

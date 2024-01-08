using MeuDia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MeuDia.Infra.Repository.Interface
{
    public interface ITaskRepository
    {
        System.Threading.Tasks.Task CreateAsync(Domain.Entities.Task task);
        System.Threading.Tasks.Task DeleteAsync(int taskId);
        System.Threading.Tasks.Task UpdateAsync(Domain.Entities.Task task);
        System.Threading.Tasks.Task<Domain.Entities.Task> GetByIdAsync(int taskId);

    }
}

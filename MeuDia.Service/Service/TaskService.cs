using MeuDia.Infra.Repository.Interface;
using MeuDia.Services.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuDia.Services.Service
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async System.Threading.Tasks.Task CreateAsync(Domain.Entities.Task task)
        {
            await _repository.CreateAsync(task);
        }

        public async System.Threading.Tasks.Task DeleteAsync(int taskId)
        {
            await _repository.DeleteAsync(taskId);
        }

        public async Task<Domain.Entities.Task> GetByIdAsync(int taskId)
        {
            return await _repository.GetByIdAsync(taskId);
        }

        public async System.Threading.Tasks.Task UpdateAsync(Domain.Entities.Task task)
        {
            await _repository.UpdateAsync(task);
        }
    }
}

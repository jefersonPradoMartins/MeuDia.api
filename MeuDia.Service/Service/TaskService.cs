using MeuDia.Domain.Entities;
using MeuDia.Infra.Repository.Interface;
using MeuDia.Services.DTO.Task;
using MeuDia.Services.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MeuDia.Domain.Entities.Task;

namespace MeuDia.Services.Service
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;
        private readonly ITagRepository _tagRepository;

        public TaskService(ITaskRepository repository, ITagRepository tagRepository)
        {
            _repository = repository;
            _tagRepository = tagRepository;
        }

        public async System.Threading.Tasks.Task CreateAsync(CreateTask task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            var nTags = new List<Tag>();

            foreach (int value in task.TagsId)
            {
                var result = await _tagRepository.GetByIdAsync(value);
                nTags.Add(result);
            }
            var nwTask = new TaskBuilder(task.Description)
                .StartAt(task.StartAt)
                .EndAt(task.EndAt)
                .CreatedAt(DateTime.Now)
                .WithTags(nTags);

            await _repository.CreateAsync(nwTask);
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

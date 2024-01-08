using MeuDia.Infra.Context;
using MeuDia.Infra.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuDia.Infra.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly MeuDiaContext _context;


        public TaskRepository(MeuDiaContext context)
        {
            _context = context;
        }

        public System.Threading.Tasks.Task CreateAsync(Domain.Entities.Task task)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task DeleteAsync(int taskId)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Task> GetByIdAsync(int taskId)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task UpdateAsync(Domain.Entities.Task task)
        {
            throw new NotImplementedException();
        }
    }
}

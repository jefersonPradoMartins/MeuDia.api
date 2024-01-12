using Azure;
using MeuDia.Domain.Entities;
using MeuDia.Infra.Context;
using MeuDia.Infra.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public async System.Threading.Tasks.Task CreateAsync(Domain.Entities.Task task)
        {
            await _context.Task.AddAsync(task);
            _context.SaveChanges();
        }

        public async System.Threading.Tasks.Task DeleteAsync(int taskId)
        {
            var result = await _context.Task.FindAsync(taskId);
            _context.Task.Remove(result);
            _context.SaveChanges();
        }

        public async Task<Domain.Entities.Task> GetByIdAsync(int taskId)
        {
            var resul1t = _context.Task.Include(x => x.Tags)
                .ThenInclude(x => x.Color).Where(x => x.TaskId == taskId).First();
          
            return resul1t;
        }

        public async System.Threading.Tasks.Task UpdateAsync(Domain.Entities.Task task)
        {
            var result = _context.Task.Update(task);
            await _context.SaveChangesAsync();
        }
    }
}

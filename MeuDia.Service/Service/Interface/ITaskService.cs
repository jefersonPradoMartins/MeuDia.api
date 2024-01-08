﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuDia.Services.Service.Interface
{
    public interface ITaskService
    {
        Task CreateAsync(Domain.Entities.Task task);
        Task DeleteAsync(int taskId);
        Task UpdateAsync(Domain.Entities.Task task);
        Task<Domain.Entities.Task> GetByIdAsync(int taskId);

    }
}

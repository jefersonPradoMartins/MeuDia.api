using MeuDia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuDia.Infra.Repository.Interface
{
    public interface IColorRepository
    {
        System.Threading.Tasks.Task CreateAsync(Color color);
        System.Threading.Tasks.Task DeleteAsync(int colorId);
        System.Threading.Tasks.Task UpdateAsync(Color taskcolor);
        System.Threading.Tasks.Task<Color> GetByIdAsync(int colorId);
    }
}

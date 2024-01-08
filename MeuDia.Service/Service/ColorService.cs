using MeuDia.Domain.Entities;
using MeuDia.Infra.Repository.Interface;
using MeuDia.Services.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuDia.Services.Service
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository _repository;

        public ColorService(IColorRepository repository)
        {
            _repository = repository;
        }

        public async System.Threading.Tasks.Task CreateAsync(Color color)
        {
            await _repository.CreateAsync(color);
        }

        public System.Threading.Tasks.Task DeleteAsync(int colorId)
        {
            throw new NotImplementedException();
        }

        public async Task<Color> GetByIdAsync(int colorId)
        {
            return await _repository.GetByIdAsync(colorId);
        }

        public System.Threading.Tasks.Task UpdateAsync(Color taskcolor)
        {
            throw new NotImplementedException();
        }
    }
}

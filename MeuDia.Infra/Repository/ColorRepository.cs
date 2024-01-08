using MeuDia.Domain.Entities;
using MeuDia.Infra.Context;
using MeuDia.Infra.Repository.Interface;


namespace MeuDia.Infra.Repository
{
    public class ColorRepository : IColorRepository
    {

        private readonly MeuDiaContext _context;

        public ColorRepository(MeuDiaContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task CreateAsync(Color color)
        {
            await _context.Color.AddAsync(color);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteAsync(int colorId)
        {
            var result = await _context.Color.FindAsync(colorId);
            _context.Color.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<Color> GetByIdAsync(int colorId)
        {
            return await _context.Color.FindAsync(colorId);
        }

        public System.Threading.Tasks.Task UpdateAsync(Color taskcolor)
        {
            throw new NotImplementedException();
        }
    }
}

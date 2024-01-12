using MeuDia.Domain.Entities;
using MeuDia.Infra.Context;
using MeuDia.Infra.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuDia.Infra.Repository
{
    public class TagRepository : ITagRepository
    {

        private readonly MeuDiaContext _context;

        public TagRepository(MeuDiaContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task CreateAsync(Tag tag)
        {
            await _context.Tag.AddAsync(tag);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteAsync(int tagId)
        {
            Tag result = _context.Tag.AsNoTracking<Tag>()
                .FirstOrDefault(x => x.TagId == tagId);
            if (result == null)
            {

            }
            else
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Tag> GetByIdAsync(int tagId)
        {

            var result = _context.Tag.Include(x => x.Color).FirstOrDefault(x => x.TagId == tagId);

            return result;
        }

        public async System.Threading.Tasks.Task UpdateAsync(Tag tag)
        {
            var result = _context.Tag.Update(tag);
            await _context.SaveChangesAsync();
        }
    }
}

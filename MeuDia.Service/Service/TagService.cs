using MeuDia.Domain.Entities;
using MeuDia.Infra.Repository.Interface;
using MeuDia.Services.DTO.Tag;
using MeuDia.Services.Service.Interface;

namespace MeuDia.Services.Service
{
    public class TagService : ITagService
    {

        private readonly ITagRepository _tagR;
        private readonly IColorRepository _colorR;

        public TagService(ITagRepository repository, IColorRepository colorRepository)
        {
            _tagR = repository;
            _colorR = colorRepository;
        }

        public async System.Threading.Tasks.Task CreateAsync(CreateTag tag)
        {
            Tag nTag = new Tag();
            nTag.Description = tag.Description;
            var color = await _colorR.GetByIdAsync(colorId: tag.ColorId);
            nTag.Color = color;

            await _tagR.CreateAsync(nTag);
        }

        public async System.Threading.Tasks.Task DeleteAsync(int tagId)
        {
            await _tagR.DeleteAsync(tagId);
        }

        public async Task<Tag> GetByIdAsync(int tagId)
        {
            return await _tagR.GetByIdAsync(tagId);
        }

        public async System.Threading.Tasks.Task UpdateAsync(Tag tag)
        {
            await _tagR.UpdateAsync(tag);
        }
    }
}

using Adapter;
using CreArtHub.App.Data;
using CreArtHub.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreArtHub.Adapter.Repository
{
    public class FileRepository : IRepository<File>
    {
        private WebDBContext context;

        public FileRepository(WebDBContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(File entity)
        {
            await context.Files.AddAsync(entity);
        }

        public async Task<File> GetByIdAsync(int id)
        {
            var ent = await context.Files
                .Include(p=>p.Post)
                .Include(c=>c.Post.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
            return ent ?? throw new NullReferenceException();
        }

        public async Task<IEnumerable<File>> GetAllAsync()
        {
            return context.Files
                .Include(p => p.Post)
				.Include(c => c.Post.Category);
        }

        public async Task UpdateAsync(File entity)
        {
            context.Files.Update(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var ent = await context.Files
                .Include(p => p.Post)
                .FirstOrDefaultAsync(x => x.Id == id);
            context.Files.Remove(ent ?? throw new NullReferenceException());
        }
    }
}

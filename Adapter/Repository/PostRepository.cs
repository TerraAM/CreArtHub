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
    public class PostRepository : IRepository<Post>
    {
        private WebDBContext context;

        public PostRepository(WebDBContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Post entity)
        {
            await context.Posts.AddAsync(entity);
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            var ent = await context.Posts
                .Include(c=>c.Category)
                .Include(u=>u.Author)
                .FirstOrDefaultAsync(x => x.Id == id);
            return ent ?? throw new NullReferenceException();
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return context.Posts
                .Include(c => c.Category)
                .Include(u => u.Author);
        }

        public async Task UpdateAsync(Post entity)
        {
            context.Posts.Update(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var ent = await context.Posts
                .Include(c => c.Category)
                .Include(u => u.Author)
                .FirstOrDefaultAsync(x => x.Id == id);
            context.Posts.Remove(ent ?? throw new NullReferenceException());
        }
    }
}

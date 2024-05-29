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
    public class CommentRepository : IRepository<Comment>
    {
        private WebDBContext context;

        public CommentRepository(WebDBContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Comment entity)
        {
            await context.Comments.AddAsync(entity);
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            var ent = await context.Comments
                .Include(p => p.Post)
                .Include(a => a.Author)
                .FirstOrDefaultAsync(x => x.Id == id);
            return ent ?? throw new NullReferenceException();
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return context.Comments
                .Include(a => a.Author)
                .Include(p => p.Post);
        }

        public async Task UpdateAsync(Comment entity)
        {
            context.Comments.Update(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var ent = await context.Comments
                .Include(a => a.Author)
                .Include(p => p.Post)
                .FirstOrDefaultAsync(x => x.Id == id);
            context.Comments.Remove(ent ?? throw new NullReferenceException());
        }
    }
}

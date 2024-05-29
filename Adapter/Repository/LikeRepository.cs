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
    public class LikeRepository : IRepository<Like>
    {
        private WebDBContext context;

        public LikeRepository(WebDBContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Like entity)
        {
            await context.Likes.AddAsync(entity);
        }

        public async Task<Like> GetByIdAsync(int id)
        {
			var ent = await context.Likes
				.FirstOrDefaultAsync(x => x.Id == id);
			return ent ?? throw new NullReferenceException();
		}

        public async Task<IEnumerable<Like>> GetByPostIdAsync(int id)
        {
			return context.Likes.Where(x => x.PostId == id);
		}

        public async Task<IEnumerable<Like>> GetByUserIdAsync(int id)
        {
			return context.Likes.Where(x=>x.UserId == id);
		}

        public async Task<IEnumerable<Like>> GetAllAsync()
        {
            return context.Likes;
        }

        public async Task UpdateAsync(Like entity)
        {
            context.Likes.Update(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
			var ent = await context.Likes
				.FirstOrDefaultAsync(x => x.Id == id);
			context.Likes.Remove(ent ?? throw new NullReferenceException());
		}
    }
}

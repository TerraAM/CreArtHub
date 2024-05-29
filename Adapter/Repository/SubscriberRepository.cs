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
    public class SubscriberRepository : IRepository<Subscriber>
    {
        private WebDBContext context;

        public SubscriberRepository(WebDBContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Subscriber entity)
        {
            await context.Subscribers.AddAsync(entity);
        }

        public async Task<Subscriber> GetByIdAsync(int id)
        {
			var ent = await context.Subscribers
				.FirstOrDefaultAsync(x => x.Id == id);
			return ent ?? throw new NullReferenceException();
		}
        public async Task<IEnumerable<Subscriber>> GetBySubscribtionIdAsync(int id)
        {
			return context.Subscribers
                .Include(x => x.Subscription)
                .Include(u => u.User)
                .Where(x => x.SubscribtionId == id);
		}
        public async Task<IEnumerable<Subscriber>> GetByUserIdAsync(int id)
        {
			return context.Subscribers
                .Include(x => x.Subscription)
                .Include(u => u.User)
                .Where(x=>x.UserId == id);
		}

        public async Task<IEnumerable<Subscriber>> GetAllAsync()
        {
            return context.Subscribers
                .Include(x => x.Subscription)
                .Include(u => u.User);
        }

        public async Task UpdateAsync(Subscriber entity)
        {
            context.Subscribers.Update(entity);
        }
        public async Task DeleteByIdAsync(int id)
        {
			var ent = await context.Subscribers
				.FirstOrDefaultAsync(x => x.Id == id);
			context.Subscribers.Remove(ent ?? throw new NullReferenceException());
		}
    }
}

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
    public class SubscriptionRepository : IRepository<Subscription>
    {
        private WebDBContext context;

        public SubscriptionRepository(WebDBContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Subscription entity)
        {
            await context.Subscriptions.AddAsync(entity);
        }

        public async Task<Subscription> GetByIdAsync(int id)
        {
            var ent = await context.Subscriptions
                .Include(a => a.Author)
                .FirstOrDefaultAsync(x => x.Id == id);
            return ent ?? throw new NullReferenceException();
        }

        public async Task<IEnumerable<Subscription>> GetAllAsync()
        {
            return context.Subscriptions
                .Include(a => a.Author);
        }

        public async Task UpdateAsync(Subscription entity)
        {
            context.Subscriptions.Update(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var ent = await context.Subscriptions
                .FirstOrDefaultAsync(x => x.Id == id);
            context.Subscriptions.Remove(ent ?? throw new NullReferenceException());
        }
    }
}


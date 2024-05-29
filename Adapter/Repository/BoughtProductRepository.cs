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
    public class BoughtProductRepository : IRepository<BoughtProduct>
    {
        private WebDBContext context;

        public BoughtProductRepository(WebDBContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(BoughtProduct entity)
        {
            await context.BoughtProducts.AddAsync(entity);
        }

        public async Task<BoughtProduct> GetByIdAsync(int id)
        {
			var ent = await context.BoughtProducts
				.FirstOrDefaultAsync(x => x.Id == id);
			return ent ?? throw new NullReferenceException();
		}
        public async Task<IEnumerable<BoughtProduct>> GetByBuyerIdAsync(int id)
        {
			return context.BoughtProducts.Where(x => x.BuyerId == id);
		}
        public async Task<IEnumerable<BoughtProduct>> GetByProductIdAsync(int id)
        {
			return context.BoughtProducts.Where(x => x.ProductId == id);
		}


        public async Task<IEnumerable<BoughtProduct>> GetAllAsync()
        {
            return context.BoughtProducts;
        }

        public async Task UpdateAsync(BoughtProduct entity)
        {
            context.BoughtProducts.Update(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
			var ent = await context.BoughtProducts
				.FirstOrDefaultAsync(x => x.Id == id);
			context.BoughtProducts.Remove(ent ?? throw new NullReferenceException());
		}
    }
}

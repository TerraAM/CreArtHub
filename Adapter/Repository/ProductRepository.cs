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
    public class ProductRepository : IRepository<Product>
    {
        private WebDBContext context;

        public ProductRepository(WebDBContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Product entity)
        {
            await context.Products.AddAsync(entity);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var ent = await context.Products
                .FirstOrDefaultAsync(x => x.Id == id);
            return ent ?? throw new NullReferenceException();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return context.Products;
        }

        public async Task UpdateAsync(Product entity)
        {
            context.Products.Update(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var ent = await context.Products
                .FirstOrDefaultAsync(x => x.Id == id);
            context.Products.Remove(ent ?? throw new NullReferenceException());
        }
    }
}

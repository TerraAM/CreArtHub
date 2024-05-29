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
    public class CategoryRepository : IRepository<Category>
    {
        private WebDBContext context;

        public CategoryRepository(WebDBContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Category entity)
        {
            await context.Categories.AddAsync(entity);
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var ent = await context.Categories
                .FirstOrDefaultAsync(x => x.Id == id);
            return ent ?? throw new NullReferenceException();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return context.Categories;
        }

        public async Task UpdateAsync(Category entity)
        {
            context.Categories.Update(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var ent = await context.Categories
                .FirstOrDefaultAsync(x => x.Id == id);
            context.Categories.Remove(ent ?? throw new NullReferenceException());
        }
    }
}

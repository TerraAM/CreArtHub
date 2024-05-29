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
    public class RoleRepository : IRepository<Role>
    {
        private WebDBContext context;

        public RoleRepository(WebDBContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Role entity)
        {
            await context.Roles.AddAsync(entity);
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            var ent = await context.Roles
                .FirstOrDefaultAsync(x => x.Id == id);
            return ent ?? throw new NullReferenceException();
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return context.Roles;
        }

        public async Task UpdateAsync(Role entity)
        {
            context.Roles.Update(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var ent = await context.Roles
                .FirstOrDefaultAsync(x => x.Id == id);
            context.Roles.Remove(ent ?? throw new NullReferenceException());
        }
    }
}

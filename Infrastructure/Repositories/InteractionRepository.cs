using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class InteractionRepository : EfRepository<Interaction>, IInteractionRepository
    {
        public InteractionRepository(ClientInfoSysDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Interaction>> GetInteractionByClient(int id)
        {
            return await _dbContext.Interactions.Where(i => i.ClientId == id).Include(i => i.Client).Include(i => i.Employee).ToListAsync();
        }

        public async Task<IEnumerable<Interaction>> GetInteractionByClientAndEmployee()
        {
            return await _dbContext.Interactions.Include(i => i.Client).Include(i => i.Employee).ToListAsync();
        }

        public async Task<IEnumerable<Interaction>> GetInteractionByEmployee(int id)
        {
            return await _dbContext.Interactions.Where(i => i.EmpId == id).Include(i => i.Client).Include(i => i.Employee).ToListAsync();
        }
    }
}

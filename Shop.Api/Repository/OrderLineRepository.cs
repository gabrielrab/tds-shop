using Microsoft.EntityFrameworkCore;
using Shop.Api.Models;
using Shop.Api.Repository.Shared;

namespace Shop.Api.Repository
{
    public class OrderLineRepository : RepositoryBase<OrderLineModel>
    {
        public OrderLineRepository(DbContext dataContext) : base(dataContext) { }

        public override async Task<IEnumerable<OrderLineModel>> GetAll()
        {
            return await Context
                .Set<OrderLineModel>()
                .Include(p => p.Product)!
                .ToListAsync();
        }

        public override async Task<OrderLineModel?> GetById(int id) =>
            await Context
                .Set<OrderLineModel>()
                .Include(p => p.Product)!
                .FirstOrDefaultAsync(i => i.Id == id);
    }
}
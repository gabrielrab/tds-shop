using Microsoft.EntityFrameworkCore;
using Shop.Api.Models;
using Shop.Api.Repository.Shared;

namespace Shop.Api.Repository
{
    public class OrderRepository : RepositoryBase<OrderModel>
    {
        public OrderRepository(DbContext dataContext) : base(dataContext) { }

        public override async Task<IEnumerable<OrderModel>> GetAll()
        {
            return await Context
                .Set<OrderModel>()
                .Include(p => p.Employee)!
                .Include(p => p.OrderLines)!
                .ThenInclude(p => p.Product)
                .ToListAsync();
        }

        public override async Task<OrderModel?> GetById(int id) =>
            await Context
                .Set<OrderModel>()
                .Include(p => p.Employee)!
                .FirstOrDefaultAsync(i => i.Id == id);
    }
}
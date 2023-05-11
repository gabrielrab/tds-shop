using Microsoft.EntityFrameworkCore;
using Shop.Api.Models;
using Shop.Api.Repository.Shared;

namespace Shop.Api.Repository
{
    public class ProductRepository : RepositoryBase<ProductModel>
    {
        public ProductRepository(DbContext dataContext) : base(dataContext)
        {
        }
    }
}
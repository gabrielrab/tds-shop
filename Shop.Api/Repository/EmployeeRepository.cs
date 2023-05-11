using Microsoft.EntityFrameworkCore;
using Shop.Api.Models;
using Shop.Api.Repository.Shared;

namespace Shop.Api.Repository
{
    public class EmployeeRepository : RepositoryBase<EmployeeModel>
    {
        public EmployeeRepository(DbContext dataContext) : base(dataContext)
        {
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using GroceryStore.Sdk;

namespace GroceryStore.Boundary.Repository
{
    public interface ReportRepository
    {
        Task<IEnumerable<ProductWithCategory>> GetProducts(int pageIndex, int elementsPerPage);
    }
}
using System;
using GroceryStore.Sdk;

namespace GroceryStore.Boundary
{
    public interface IProductRepository
    {
        public Guid Save(Product product);

        public Product Get(Guid productId);
    }
}

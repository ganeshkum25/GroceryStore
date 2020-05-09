using System;
using GroceryStore.Sdk;

namespace GroceryStore.Boundary.Repository
{
    public interface ProductRepository
    {
        Guid Save(Product product);

        Product Get(Guid productId);
    }
}
using System;
using GroceryStore.Sdk;

namespace GroceryStore.Boundary.Repository
{
    public interface CategoryRepository
    {
        Guid Save(Category product);

        Category Get(Guid productId);
    }
}
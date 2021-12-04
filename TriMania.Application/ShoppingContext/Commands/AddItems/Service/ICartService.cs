using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriMania.Domain.Shopping;

namespace TriMania.Application.ShoppingContext.AddItems.Service
{
    public interface ICartService
    {
        Task<bool> IsAbleToAddAsync(AddItemsProductCommand item, Order order);
        Task<bool> AddAsync(AddItemsProductCommand item, Order order);
        Task<bool> IsAbleToUpdateAsync(AddItemsProductCommand item, Order order);
        Task<bool> UpdateAsync(AddItemsProductCommand item, Order order);
        Task<bool> IsAbleToDeleteAsync(AddItemsProductCommand item, Order order);
        Task<bool> DeleteAsync(AddItemsProductCommand item, Order order);

    }
}

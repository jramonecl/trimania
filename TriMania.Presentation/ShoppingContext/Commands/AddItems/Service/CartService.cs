using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trimania.Shared.Exceptions;
using TriMania.Domain.Shopping;
using TriMania.Domain.Shopping.Repositories;

namespace TriMania.Application.ShoppingContext.AddItems.Service
{
    public class CartService : ICartService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderItemRepository _orderItemRepository;

        public CartService(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _orderItemRepository = orderItemRepository;
        }
        public async Task<bool> IsAbleToAddAsync(AddItemsProductCommand item, Order order)
        {
            var product = await _productRepository.GetByIdAsync(item.ProductId);
            var orderItem = await _orderItemRepository.GetOrderItemFromOrder(order.Id, item.ProductId);

            if (product == null)
            {
                throw new BusinessRuleException("Produto não encontrado");
            }

            return item.ActionParsed == Action.Insert && orderItem == null;
        }
        public async Task<bool> AddAsync(AddItemsProductCommand item, Order order)
        {
            var product = await _productRepository.GetByIdAsync(item.ProductId);
            var orderItem = await _orderItemRepository.GetOrderItemFromOrder(order.Id, item.ProductId);

            if (product == null)
            {
                throw new BusinessRuleException("Produto não encontrado");
            }
            await _orderItemRepository.InsertAsync(OrderItem.CreateNew(product.Id, order.Id, product.Price, item.Quantity));

            return true;
        }
        public async Task<bool> IsAbleToUpdateAsync(AddItemsProductCommand item, Order order)
        {
            var product = await _productRepository.GetByIdAsync(item.ProductId);
            var orderItem = await _orderItemRepository.GetOrderItemFromOrder(order.Id, item.ProductId);

            if (product == null)
            {
                throw new BusinessRuleException("Produto não encontrado");
            }

            if ((item.ActionParsed == Action.Insert && orderItem != null))
            {
                item.AdjustQuantityBy(orderItem.Quantity);
                return true;
            }

            return item.ActionParsed == Action.Update && orderItem != null;
        }
        public async Task<bool> UpdateAsync(AddItemsProductCommand item, Order order)
        {
            var product = await _productRepository.GetByIdAsync(item.ProductId);
            var orderItem = await _orderItemRepository.GetOrderItemFromOrder(order.Id, item.ProductId);

            if (product == null)
            {
                throw new BusinessRuleException("Produto não encontrado");
            }

            orderItem.SetQuantity(item.Quantity);
            orderItem.SetPrice(product.Price);

            await _orderItemRepository.UpdateAsync(orderItem);

            return true;
        }
        public async Task<bool> IsAbleToDeleteAsync(AddItemsProductCommand item, Order order)
        {
            var product = await _productRepository.GetByIdAsync(item.ProductId);
            var orderItem = await _orderItemRepository.GetOrderItemFromOrder(order.Id, item.ProductId);

            if (product == null)
            {
                throw new BusinessRuleException("Produto não encontrado");
            }

            return item.ActionParsed == Action.Delete && orderItem != null;
        }
        public async Task<bool> DeleteAsync(AddItemsProductCommand item, Order order)
        {
            var product = await _productRepository.GetByIdAsync(item.ProductId);
            var orderItem = await _orderItemRepository.GetOrderItemFromOrder(order.Id, item.ProductId);

            if (product == null)
            {
                throw new BusinessRuleException("Produto não encontrado");
            }

            await _orderItemRepository.DeleteAsync(orderItem);

            return true;
        }
    }
}

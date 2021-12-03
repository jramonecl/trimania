using System;
using System.Collections.Generic;
using System.Linq;
using Trimania.Shared.Exceptions;
using TriMania.Domain.Base;

namespace TriMania.Domain.Shopping
{
    public class Order : Entity
    {
        public Order() : this(0)
        {
            
        }

        private Order(int id) : this(id, OrderStatus.Opened)
        {
        }

        private Order(int id, OrderStatus status)
        {
            UserId = id;
            Status = status;
            Items = new List<OrderItem>();
            CreationDate = DateTime.Now;
            CancelDate = null;
            FinishedDate = null;
        }

        public int UserId { get; private set; }
        public User.User User { get; private set; }

        public decimal TotalValue
        {
            get { return Items.Any() ? Items.Sum(n => n.Price * n.Quantity) : 0; }
        }

        public ICollection<OrderItem> Items { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime? CancelDate { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime? FinishedDate { get; private set; }

        public static Order CreateNew(int id)
        {
            return new(id);
        }

        public void SetStatus(OrderStatus requestStatus)
        {
            Status = requestStatus;
        }

        public void Checkout(OrderStatus requestStatus)
        {
            if (Status == OrderStatus.Cancelled || Status == OrderStatus.Completed)
            {
                throw new BusinessRuleException("Pedido não pode mais ser modificado");
            }

            if (requestStatus == OrderStatus.Opened || requestStatus == OrderStatus.InProgress)
            {
                throw new BusinessRuleException("Status não permitido");
            }

            CancelDate = requestStatus == OrderStatus.Cancelled ? DateTime.Now : null;
            FinishedDate = requestStatus == OrderStatus.Completed ? DateTime.Now : null;
            Status = requestStatus;
        }

        public void InsertItems(List<OrderItem> items)
        {
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }
    }
}
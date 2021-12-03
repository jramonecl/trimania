using System;
using TriMania.Domain.Base;

namespace TriMania.Domain.Shopping
{
    public class Product : Entity
    {
        public Product()
        {

        }
        private Product(string Name, decimal Price)
        {
            this.Name = Name;
            this.Price = Price;
        }
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public static Product CreateNew(string Name, decimal Price)
        {
            return new Product(Name, Price);
        }

        public static Product CreateNew(string v)
        {
            throw new NotImplementedException();
        }
    }
}
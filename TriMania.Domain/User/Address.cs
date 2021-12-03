using TriMania.Domain.Base;

namespace TriMania.Domain.User
{
    public class Address : Entity
    {
        public Address()
        {

        }
        private Address(string Street, string Neighborhood, int Number, string City, string State)
        {
            this.Street = Street;
            this.Neighborhood = Neighborhood;
            this.Number = Number;
            this.City = City;
            this.State = State;
        }

        public string Street { get; private set; }
        public string Neighborhood { get; private set; }
        public int Number { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }

        public static Address Create(string Street, string Neighborhood, int Number, string City, string State)
        {
            return new(Street, Neighborhood, Number, City, State);
        }

        public void Update(string Street, string Neighborhood, int Number, string City, string State)
        {
            this.Street = Street;
            this.Neighborhood = Neighborhood;
            this.Number = Number;
            this.City = City;
            this.State = State;
        }
    }
}
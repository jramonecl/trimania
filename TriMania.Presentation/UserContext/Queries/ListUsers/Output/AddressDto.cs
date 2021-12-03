namespace TriMania.Application.UserContext.Queries.ListUsers
{
    public class AddressDto
    {
        public string Street { get; private set; }
        public string Neighborhood { get; private set; }
        public int Number { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
    }
}
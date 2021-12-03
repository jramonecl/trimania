namespace TriMania.Application.UserContext.Commands.Register
{
    public class RegisterAddressCommand
    {
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
using MediatR;

namespace TriMania.Application.UserContext.Commands.Authenticate
{
    public class AuthenticateCommand : IRequest<string>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
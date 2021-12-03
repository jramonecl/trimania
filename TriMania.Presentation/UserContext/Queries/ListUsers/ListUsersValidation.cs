using FluentValidation;

namespace TriMania.Application.UserContext.Queries.ListUsers
{
    public class ListUsersValidation : AbstractValidator<ListUsersQuery>
    {
        public ListUsersValidation()
        {
            RuleFor(n => n.Page).GreaterThan(0).WithMessage("Página inexistente");
        }
    }
}
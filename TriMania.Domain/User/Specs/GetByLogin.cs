using Trimania.Shared.Data;

namespace TriMania.Domain.User.Specs
{
    public class GetByLogin : BaseSpecifcation<User>
    {
        public GetByLogin(string login)
        {
            AddCriteria(n => n.Login == login);
        }
    }
}

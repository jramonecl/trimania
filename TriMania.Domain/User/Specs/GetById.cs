using Trimania.Shared.Data;

namespace TriMania.Domain.User.Specs
{
    public class GetById : BaseSpecifcation<User>
    {
        public GetById(int id)
        {
            AddCriteria(n => n.Id == id);
            AddInclude(n => n.Address);
        }
    }
}
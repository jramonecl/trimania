using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trimania.Shared.Data;

namespace TriMania.Domain.Shopping.Specs
{
    public class GetByTerm : BaseSpecifcation<User.User>
    {
        public GetByTerm(string term)
        {
            if (!string.IsNullOrEmpty(term))
            {
                AddCriteria(n => n.Name.Contains(term) || n.Email.Contains(term) || n.Login.Contains(term));
            }
        }
    }
}

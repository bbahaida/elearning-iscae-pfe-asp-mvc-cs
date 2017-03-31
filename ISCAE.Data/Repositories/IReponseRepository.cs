using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public interface IReponseRepository : IRepository<Repons>
    {
        IEnumerable<Repons> GetReponsesByQuestion(int QuestionId, int pageIndex, int pageSize);
    }
}

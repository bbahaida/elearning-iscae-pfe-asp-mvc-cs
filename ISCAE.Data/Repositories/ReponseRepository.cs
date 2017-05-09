using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public class ReponseRepository : Repository<IscaeEntities, Repons>, IReponseRepository
    {
        public IEnumerable<Repons> GetReponsesByQuestion(int QuestionId, int pageIndex, int pageSize)
        {
            try
            {
                return Context.Set<Repons>().Where(o => o.QuestionId == QuestionId).OrderBy(o => o.QuestionId).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }
    }
}

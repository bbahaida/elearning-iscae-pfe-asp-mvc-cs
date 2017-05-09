using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public class QuestionRepository : Repository<IscaeEntities, Question>, IQuestionRepository
    {
        public IEnumerable<Question> GetQuestionsByEtudiant(int EtudiantId, int pageIndex, int pageSize)
        {
            try
            {
                return Context.Set<Question>().Where(o => o.EtudiantId == EtudiantId).OrderByDescending(o => o.QuestionId).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        public IEnumerable<Question> GetQuestionsBySpecialite(int SpecialiteId, int Niveau, int pageIndex, int pageSize)
        {
            try
            {
                return Context.Set<Question>().Where(o => o.Etudiant.SpecialiteId == SpecialiteId && o.Etudiant.Niveau == Niveau).OrderByDescending(o => o.QuestionId).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }
    }
}

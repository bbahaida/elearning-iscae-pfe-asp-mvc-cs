using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Business.Services
{
    public interface IQuestionService :ICommonService<Question>
    {
        IEnumerable<Question> GetQuestionsByEtudiant(int EtudiantId, int pageIndex, int pageSize);
        int CountQuestionsBySpecialite(int SpecialiteId, int Niveau);
        IEnumerable<Question> GetQuestionsBySpecialite(int SpecialiteId, int Niveau, int pageIndex, int pageSize);
    }
}


using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Business.Services
{
    public interface IReponseService : ICommonService<Repons>
    {
        IEnumerable<Repons> GetReponsesByQuestion(int QuestionId, int pageIndex, int pageSize);
    }
}

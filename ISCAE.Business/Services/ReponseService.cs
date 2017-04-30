using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISCAE.Data.Repositories;

namespace ISCAE.Business.Services
{
    public class ReponseService : CommonService<Repons>, IReponseService
    {
        private IReponseRepository _reponseRepository;
        private IQuestionService _questionService;
        public ReponseService(IUnitOfWork unit , IQuestionService questionService) : base(unit.Reponses)
        {
            _reponseRepository = unit.Reponses;
            _questionService = questionService;
        }

        public IEnumerable<Repons> GetReponsesByQuestion(int QuestionId, int pageIndex, int pageSize)
        {
            if (QuestionId <= 0 || _questionService.Get(QuestionId) == null || pageIndex <= 0 || pageSize <= 0)
                return null;
            return _reponseRepository.GetReponsesByQuestion(QuestionId, pageIndex, pageSize);
        }
    }
}

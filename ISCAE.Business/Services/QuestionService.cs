using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISCAE.Data.Repositories;

namespace ISCAE.Business.Services
{
    public class QuestionService : CommonService<Question>, IQuestionService
    {
        private IQuestionRepository _questionRepository;
        private IEtudiantRepository _etudiantRepository;
        public QuestionService(IQuestionRepository repository, IEtudiantRepository etudiantRepository) : base(repository)
        {
            _questionRepository = repository;
            _etudiantRepository = etudiantRepository;
        }

        public IEnumerable<Question> GetQuestionsByEtudiant(int EtudiantId, int pageIndex, int pageSize)
        {
            if (EtudiantId <= 0 || _etudiantRepository.Get(EtudiantId) == null || pageIndex <= 0 || pageSize <= 0)
                return null;
            return _questionRepository.GetQuestionsByEtudiant(EtudiantId,pageIndex,pageSize);
        }
    }
}

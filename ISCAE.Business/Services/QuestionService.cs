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
        private ISpecialiteRepository _specialiteRepository;
        public QuestionService(IUnitOfWork unit) : base(unit.Questions)
        {
            _questionRepository = unit.Questions;
            _etudiantRepository = unit.Etudiants;
            _specialiteRepository = unit.Specialites;
        }

        public IEnumerable<Question> GetQuestionsByEtudiant(int EtudiantId, int pageIndex, int pageSize)
        {
            if (EtudiantId <= 0 || _etudiantRepository.Get(EtudiantId) == null || pageIndex <= 0 || pageSize <= 0)
                return null;
            return _questionRepository.GetQuestionsByEtudiant(EtudiantId,pageIndex,pageSize);
        }
        public int CountQuestionsBySpecialite(int SpecialiteId, int Niveau)
        {
            if (SpecialiteId <= 0 || _specialiteRepository.Get(SpecialiteId) == null || Niveau < 1 || Niveau > 3)
                return 0;
            return _questionRepository.GetAll().Where(o=>o.Etudiant.SpecialiteId == SpecialiteId && o.Etudiant.Niveau == Niveau).Count();
        }
        public IEnumerable<Question> GetQuestionsBySpecialite(int SpecialiteId, int Niveau, int pageIndex, int pageSize)
        {
            if (SpecialiteId <= 0 || _specialiteRepository.Get(SpecialiteId) == null || Niveau < 1 || Niveau > 3 || pageIndex < 1 || pageSize < 1)
                return null;
            return _questionRepository.GetQuestionsBySpecialite(SpecialiteId,Niveau,pageIndex,pageSize);
        }
    }
}

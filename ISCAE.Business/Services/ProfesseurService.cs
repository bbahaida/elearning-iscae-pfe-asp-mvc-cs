﻿using ISCAE.Data;
using System.Collections.Generic;
using ISCAE.Data.Repositories;
using System;
using System.Linq;

namespace ISCAE.Business.Services
{
    public class ProfesseurService : CommonService<Professeur>, IProfesseurService
    {
        private IProfesseurRepository _professeurRepository;
        private IProfesseurModuleRepository _professeurModuleRepository;
        private IProfesseurSpecialiteRepository _professeurSpecialiteRepository;
        private ISpecialiteModuleRepository _specialiteModuleRepository;
        private ISpecialiteModuleService _specialiteModuleService;
        private IModuleRepository _moduleRepository;
        public ProfesseurService(IProfesseurRepository repository, IProfesseurModuleRepository professeurModuleRepository, IModuleRepository moduleRepository,
               IProfesseurSpecialiteRepository professeurSpecialiteRepository, ISpecialiteModuleRepository specialiteModuleRepository,
               ISpecialiteModuleService specialiteModuleService) : base(repository)
        {
            _professeurRepository = repository;
            _professeurModuleRepository = professeurModuleRepository;
            _professeurSpecialiteRepository = professeurSpecialiteRepository;
            _specialiteModuleRepository = specialiteModuleRepository;
            _moduleRepository = moduleRepository;
            _specialiteModuleService = specialiteModuleService;

        }

        public IEnumerable<Professeur> GetActiveUsers()
        {
            return _professeurRepository.GetActiveUsers();
        }

        public IEnumerable<Professeur> GetNonActiveUsers()
        {
            return _professeurRepository.GetNonActiveUsers();
        }

        public Dictionary<Module, Professeur> GetProfesseursBySpecialiteAndNiveau(int SpecialiteId, int Niveau)
        {
            if (SpecialiteId < 1 || Niveau < 1 || Niveau > 3)
                return null;
            Dictionary<Module,Professeur> profs = new Dictionary<Module, Professeur>();
            
            List<SpecialiteModule> sm = _specialiteModuleRepository.GetSpecialiteModulesByNiveau(SpecialiteId, Niveau).ToList();
            List<ProfesseurSpecialite> ps = _professeurSpecialiteRepository.GetProfesseursBySpecialite(SpecialiteId).ToList();
            List<ProfesseurModule> pm = _professeurModuleRepository.GetAll().ToList();
            foreach (ProfesseurModule p in pm)
            {
                foreach (ProfesseurSpecialite s in ps)
                {
                    if (p.ProfesseurId == s.ProfesseurId)
                    {
                        foreach (SpecialiteModule m in sm)
                        {
                            if (s.SpecialiteId == m.SpecialiteId && p.ModuleId == m.ModuleId && m.Niveau == Niveau)
                            {
                                profs.Add(_moduleRepository.Get(m.ModuleId), _professeurRepository.Get(s.ProfesseurId));
                            }
                        }
                    }
                    
                }
            }
            return profs;
        }

        public Professeur GetUserByAuth(string login, string password)
        {
            if (login.Equals("") || password.Equals(""))
                return null;
            return _professeurRepository.GetUserByAuth(login, password);
        }

        public Professeur GetUserByEmail(string email)
        {
            if (email.Equals(""))
                return null;
            return _professeurRepository.GetUserByEmail(email);
        }

        public Professeur GetUserByLogin(string login)
        {
            if (login.Equals(""))
                return null;
            return _professeurRepository.GetUserByLogin(login);
        }

        public Professeur GetUserByTelephone(string telephone)
        {
            if (telephone.Equals(""))
                return null;
            return _professeurRepository.GetUserByTelephone(telephone);
        }

        public Dictionary<int, List<int>> GetSpecialiteWithNiveau(int ProfesseurId)
        {
            List<ProfesseurSpecialite> professeurSpecialites = _professeurSpecialiteRepository.GetSpecialitesByProfesseur(ProfesseurId).ToList();
            Dictionary<int, List<int>> niveauBySpecialite = new Dictionary<int, List<int>>();
            List<ProfesseurModule> professeurModules = _professeurModuleRepository.GetModulesByProfesseur(ProfesseurId).ToList();

            foreach (ProfesseurSpecialite p in professeurSpecialites)
            {
                bool uTeach = false;
                List<int> niveau = new List<int>();
                List<SpecialiteModule> sm = _specialiteModuleRepository.GetSpecialiteModulesBySpecialite(p.SpecialiteId).ToList();
                foreach (ProfesseurModule m in professeurModules)
                {
                    foreach (SpecialiteModule s in sm)
                    {
                        if (s.ModuleId == m.ModuleId)
                        {
                            uTeach = true;
                            niveau.Add(_specialiteModuleService.GetNiveauBySpecialiteAndModule(p.SpecialiteId, s.ModuleId));
                        }
                    }
                }
                if (uTeach)
                    niveauBySpecialite.Add(p.SpecialiteId, niveau);
            }
            return niveauBySpecialite;
        }
    }
}

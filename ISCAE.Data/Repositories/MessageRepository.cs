﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public class MessageRepository : Repository<IscaeEntities, Message>, IMessageRepository
    {
        public IEnumerable<Message> GetMessagesByProfesseur(int ProfesseurId, int pageIndex, int pageSize)
        {
            return Context.Set<Message>().Where(o => o.ProfesseurId == ProfesseurId).OrderByDescending(o=>o.MessageId).Skip((pageIndex-1)*pageSize).Take(pageSize).AsEnumerable();
        }

        public IEnumerable<Message> GetMessagesByProfesseurAndSpecialite(int ProfesseurId, int SpecialiteId, int Niveau, int pageIndex, int pageSize)
        {
            return Context.Set<Message>().Where(o => o.ProfesseurId == ProfesseurId && o.SpecialiteId == SpecialiteId && o.Niveau == Niveau).OrderByDescending(o => o.MessageId).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsEnumerable();
        }
    }
}

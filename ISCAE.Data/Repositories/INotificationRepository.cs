using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public interface INotificationRepository : IRepository<Notification>
    {
        IEnumerable<Notification> GetUnreadNotifications(int TargetId);
    }
}

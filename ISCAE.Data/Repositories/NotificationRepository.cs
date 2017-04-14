using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCAE.Data.Repositories
{
    public class NotificationRepository : Repository<IscaeEntities, Notification>, INotificationRepository
    {
        public IEnumerable<Notification> GetUnreadNotifications(int TargetId)
        {
            try
            {
                return Context.Set<Notification>().Where(o => o.TargetId == TargetId && o.NotificationStatus == 0).AsEnumerable();
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return null;
            }
        }

        
    }
}

using ISCAE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISCAE.Data.Repositories;

namespace ISCAE.Business.Services
{
    public class NotificationService : CommonService<Notification>, INotificationService
    {
        private INotificationRepository _notificationRepository;
        public NotificationService(IUnitOfWork unit) : base(unit.Notifications)
        {
            _notificationRepository = unit.Notifications;
        }

        public IEnumerable<Notification> GetUnreadNotifications(int TargetId)
        {
            if (TargetId < 1)
                return null;
            return _notificationRepository.GetUnreadNotifications(TargetId);
        }

        public void TroncateNotifications()
        {
            var notifications = _notificationRepository.Find(o => o.NotificationStatus == 1).Take(100);
            foreach (Notification notification in notifications)
            {
                if (_notificationRepository.Delete(notification) != null)
                    throw new Exception("Erreur lors de suppression d'un objet");
            }
        }
    }
}

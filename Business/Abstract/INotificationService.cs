using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Dto;

namespace Business.Abstract
{
    public interface INotificationService
    {
        List<Notification> GetAll();
        Notification GetById(int id);
        void Add(Notification notification);
        void Update(Notification notification);
        void Delete(Notification notification);
        List<NotificationDto> GetAllNotificationDtos();
    }
}

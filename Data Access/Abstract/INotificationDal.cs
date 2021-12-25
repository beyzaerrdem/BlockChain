using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Dto;

namespace Data_Access.Abstract
{
    public interface INotificationDal : IRepository<Notification>
    {
        List<NotificationDto> GetAllNotificationDtos();
    }
}

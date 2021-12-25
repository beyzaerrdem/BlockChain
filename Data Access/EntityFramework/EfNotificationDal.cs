using Data_Access.Abstract;
using Data_Access.Concrete.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access.Concrete;
using Entities.Dto;

namespace Data_Access.EntityFramework
{
    public class EfNotificationDal : GenericRepository<Notification> ,INotificationDal
    {
        public List<NotificationDto> GetAllNotificationDtos()
        {
            using (var db = new Context())
            {
                //return db.NotificationView.ToList();
                return null;
            }
        }
    }
}

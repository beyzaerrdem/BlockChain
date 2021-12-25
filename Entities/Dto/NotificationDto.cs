using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Dto
{
    [Table("NotificationView")]
    public class NotificationDto
    {
        public string UserName { get; set; }
        public string ProfilPhoto { get; set; }
        public string Message { get; set; }
    }
}
using Entitites.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Entities
{


    [Table("TB_NEWS")]
    public class News : Notification
    {

        [Column("NTC_ID")]
        public int Id { get; set; }

        [Column("NTC_TITLE")]
        [MaxLength(255)]
        public string Title { get; set; }

        [MaxLength(255)]

        [Column("NTC_INFORMATION")]
        public string Information { get; set; }


        [Column("NTC_ACTIVE")]
        public bool Active { get; set; }


        [Column("NTC_REGISTER")]
        public DateTime RegisterData { get; set; }


        public DateTime UpdateData { get; set; }

        //EF RELATIONS


        [ForeignKey("ApplicationUser")]
        [Column(Order = 1)]

        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }



    }
}

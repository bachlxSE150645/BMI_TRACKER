using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class notification
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid notificationId { get; set; }
        public string? notificationName { get; set; }
        public string? content { get; set; }
        public  notificationType[] type {get;set;}
        public string status { get; set; }


        public user users { get; set; }
    }
    public enum notificationType
    {
        ingredient = 0,
        food = 1, 
        menu = 2,
        othher = 3,
    }
}

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
    public class userBodyMax
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid userInfoId {  get; set; }
        [Required]
        public int heght { get; set; }
        [Required]
        public int weight {  get; set; }
        [Required]
        public int age { get; set; }
        public float BMIPerson { get; set; }
        public int minimum_calories { get; set; }
        public int maximum_calories { get; set; }
        public string photo { get; set; }
        public string status { get; set; }
        [ForeignKey("user")]
        public Guid userId { get; set; }
        public  user users { get; set; }
        [ForeignKey("service")]
        public Guid serviceId { get; set; }

        public ICollection<Schedule> schedules { get; set; }

        public Service services { get; set; }
    }
}

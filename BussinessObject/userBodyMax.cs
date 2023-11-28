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
        public double BMIPerson { get; set; }
        public double BMR { get; set; }
        public double TDEE { get; set; }
        public sexType sex { get; set; }
        public string status { get; set; }
        [ForeignKey("user")]
        public Guid userId { get; set; }
        public  user users { get; set; }
        [ForeignKey("service")]
        public Guid serviceId { get; set; }
        public Service services { get; set; }
        public ICollection<Schedule> schedules { get; set; }
       

    }
    public enum sexType
    {
        male = 0,
        female = 1
    }
}

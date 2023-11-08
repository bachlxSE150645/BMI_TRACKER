
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class user
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid userId { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string email { get; set; }
        public string fullName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string password { get; set; }
        
        [ForeignKey("notification")]
        public Guid notificationId { get; set; }
        public string sex {  get; set; }

        [DataType(DataType.PhoneNumber)]
        public string phoneNumber { get; set; }
        public string certificateId { get; set; }
        public string certificateName { get; set; }
        public string status { get; set; }
        public string createBy { get; set; }
        public DateTime createTime { get; set; }
        public string updateBy { get; set; }
        public DateTime updateTime { get; set; }
        [ForeignKey("role")]
        public Guid roleId { get; set; }
        public role roles { get; set; }
        
        public ICollection<trackForm> trackForms { get; set; }

        [JsonIgnore]
        public userBodyMax userBodyMaxs { get; set; }
        [JsonIgnore]

        public ICollection<Content> contents { get; set; }
        [JsonIgnore]

        public ICollection<favoriteFood> favoriteFoods { get; set; }
        [JsonIgnore]

        public ICollection<chatSection> chatSections { get; set; }
        [JsonIgnore]

        public ICollection <feedback> feedbacks { get; set; }
        [JsonIgnore]
        public notification notifications { get; set; }
        [JsonIgnore]
        public ICollection <complement> complements { get; set; }
    }
}


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
        

        [DataType(DataType.PhoneNumber)]
        public string phoneNumber { get; set; }
        public string certificateId { get; set; }
        public string certificateName { get; set; }
        public string status { get; set; }
 
        [ForeignKey("role")]
        public Guid roleId { get; set; }
        public role roles { get; set; }
        [JsonIgnore]
        public ICollection<trackForm> trackForms { get; set; }

        [JsonIgnore]
        public userBodyMax userBodyMaxs { get; set; }
        [JsonIgnore]

        public ICollection<blog> blogs { get; set; }
        [JsonIgnore]

        public ICollection<favoriteFood> favoriteFoods { get; set; }
        [JsonIgnore]

        public ICollection<chatSection> chatSections { get; set; }
        [JsonIgnore]

        public ICollection <feedback> feedbacks { get; set; }
        [JsonIgnore]
        public ICollection <notification> notifications { get; set; }
        [JsonIgnore]
        public ICollection <complementBlog> complementBlogs { get; set; }
        [JsonIgnore]
        public ICollection<ComplementService> ComplementServices { get; set; }
       
    }
}

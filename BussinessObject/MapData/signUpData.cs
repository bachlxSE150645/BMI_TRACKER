using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BussinessObject.user;

namespace BussinessObject.MapData
{
    public class signUpData
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        public string email { get; set; }
        public string fullName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string password { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string phoneNumber { get; set; }

    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.MapData
{
    public class loginData
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        public string email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string password { get; set; }
       
    }
}

﻿
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
    public class role
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid roleId { get; set; }
        public string roleName { get; set; }
        public string status { get; set; }
        [JsonIgnore]
        public virtual ICollection<user> users { get; set; }
        
    }
}

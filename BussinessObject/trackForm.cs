﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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
    [PrimaryKey(nameof(trackFormId), nameof(serviceId), nameof(userId))]

    public class trackForm
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid trackFormId { get; set; }
        public string trackFormName { get; set; }
        public string trackeFormDescription {  get; set; }
        public string status { get; set; }
        [ForeignKey("user")]
        public Guid userId { get; set; }
        public user users { get; set; }
        [ForeignKey("service")]
        public Guid serviceId { get; set; }
        public Service services { get; set; }

    }
}

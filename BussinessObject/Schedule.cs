using Microsoft.EntityFrameworkCore;
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
    [PrimaryKey(nameof(MenuId),nameof(userInfoId))]
    public class Schedule
    {
        [ForeignKey("menu")]
        public Guid MenuId { get; set; }
        [ForeignKey("userBodyMax")]
        public Guid userInfoId { get; set; }
        public userBodyMax userBodyMaxs { get; set; }
        public Menu menus { get; set; }
        public string status { get; set; }
       
    }
}

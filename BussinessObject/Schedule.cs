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
    [PrimaryKey(nameof(menuId),nameof(userInfoId))]
    public class Schedule
    {
        [ForeignKey("menu")]
        public Guid menuId { get; set; }
        [ForeignKey("userBodyMax")]
        public Guid userInfoId { get; set; }
        public int dateScheduled {  get; set; }
        public string status { get; set; }

        public userBodyMax userBodyMaxs { get; set; }
        [ForeignKey("trackForm")]
        public Guid trackFormId { get; set; }
        public trackForm trackForms { get; set; }
        public Menu menus { get; set; }
    }
}

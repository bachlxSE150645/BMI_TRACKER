using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    [PrimaryKey(nameof(userId),nameof(blogId))]
    public class Content
    {
        [ForeignKey("user")]
        public Guid userId { get; set; }
        [ForeignKey("blog")]
        public Guid blogId { get; set; }

        public blog blogs { get; set; }
        public user users {  get; set; }
    }
}

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
    public class message
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid messageId { get; set; }
        public string? Content { get; set; }
        public string? file {  get; set; }
        public string status { get; set; }
        [JsonIgnore]

        public ICollection<chatSection> chatSections { get; set; }

    }
}

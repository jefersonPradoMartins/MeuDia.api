using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeuDia.Domain.Entities
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Description { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
        [JsonIgnore]
        public List<Task> Tasks { get; set; }

        public Tag() { }
    }
}

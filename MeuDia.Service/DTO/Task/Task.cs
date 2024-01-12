using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeuDia.Services.DTO.Task
{
    public record CreateTask
    {
        [Required(ErrorMessage = "O campo Description é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo Description deve ser do tipo string ou array com comprimento máximo de '100'.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "O campo StartAt é obrigatório.")]
        public DateTime StartAt { get; set; }
        [Required(ErrorMessage = "O campo EndAt é obrigatório.")]
        public DateTime EndAt { get; set; }
        [Required(ErrorMessage = "O campo TagsId é obrigatório.")]
        public List<int> TagsId { get; set; }
    }
}

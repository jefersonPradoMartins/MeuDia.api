using MeuDia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeuDia.Services.DTO.Tag
{
    [MetadataType(typeof(CreateTag))]
    public record class CreateTag
    {
        [JsonPropertyName("Description")]
        [Required(ErrorMessage = "O campo Description é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo Description deve ser do tipo string ou array com comprimento máximo de '100'.")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("ColorId")]
        [Required(ErrorMessage = "O campo ColorId é obrigatório.")]
        public int ColorId { get; set; }
    }
}


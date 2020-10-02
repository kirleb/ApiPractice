using System.ComponentModel.DataAnnotations;

namespace ApiPractice.Dtos
{
    public class CommandCreateDto
    {
        [Required]
        [MaxLength(80)]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}
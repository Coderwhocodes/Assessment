using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace try2.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage ="Name cannot exceed 50 characters.")]
        public string Name { get; set; }

        public string Class { get; set; } = "Unknown";
    }
}

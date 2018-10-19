using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Contact
    {
        [Required]
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [MaxLength(50), MinLength(2)]
        public String FirstName { get; set; }

        [MaxLength(50), MinLength(2)]
        public String LastName { get; set; }

        [EmailAddress]
        public String Email { get; set; }

    }
}

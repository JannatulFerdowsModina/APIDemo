using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Author { get; set; }
        [Required]
        public string Title { get; set; }
        public string  Publisher { get; set; }
        [Required]
        public int ISBN { get; set; }
    }
}

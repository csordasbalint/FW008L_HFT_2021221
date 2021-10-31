using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW008L_HFT_2021221.Models
{
    [Table("People")]
    public class Person
    {
        [Key]
        public int  Person_Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Age { get; set; }

        public string Nationality { get; set; }

        [NotMapped]
        public virtual ICollection<Book> Books { get; set; }

        public Person()
        {
            Books = new HashSet<Book>();
        }

    }
}

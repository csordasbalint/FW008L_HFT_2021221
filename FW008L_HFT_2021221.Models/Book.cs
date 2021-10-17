using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW008L_HFT_2021221.Models
{
    public class Book
    {
        [Key]
        public int Book_Id { get; set; }

        public string Title { get; set; }

        public int Published { get; set; }

        [NotMapped]
        public virtual Writer Writer { get; set; }

        [ForeignKey(nameof(Writer))]
        public int Writer_Id { get; set; }

    }
}

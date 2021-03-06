using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FW008L_HFT_2021221.Models
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int Book_Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public int Published { get; set; }

        public string Genre { get; set; }


        [NotMapped]
        [JsonIgnore]
        public virtual Writer Writer { get; set; }

        [ForeignKey(nameof(Writer))]
        public int Writer_Id { get; set; }


        [NotMapped]
        [JsonIgnore]
        public virtual Person Person { get; set; }

        [ForeignKey(nameof(Person))]
        public Nullable<int> Person_Id { get; set; }

    }
}

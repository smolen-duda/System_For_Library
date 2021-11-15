using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library
{
    public class Book
    {
        [Key]
        public int BookID {get;set;}
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }
        public int Year { get; set; }
      
        
        public int TopicID { get; set; }
        [ForeignKey("TopicID")]
        public virtual Topic Topic { get; set; }
        public virtual ICollection<Copy> Copies { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }
    }
}

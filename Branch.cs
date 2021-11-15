using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Library
{
    public class Branch
    {
        public int BranchID { get; set; }
        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }
     
        public virtual ICollection<Copy> Copies { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}

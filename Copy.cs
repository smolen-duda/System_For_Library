using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library
{
    public class Copy
    {
        public int CopyID { get; set; }
        public string Status { get; set; }

        public int BranchID { get; set; }
        [ForeignKey("BranchID")]
        [Required(ErrorMessage = "BranchID is required")]
        public Branch Branch { get; set; }

        public int BookID { get; set; }
        [ForeignKey("BookID")]
        [Required(ErrorMessage = "BookID is required")]
        public Book Book { get; set; }
     
        public virtual ICollection<Borrowing> Borrowings { get; set; }
    }
}

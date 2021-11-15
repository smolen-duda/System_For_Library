using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library
{
    public class Borrowing
    {

        public int BorrowingID { get; set; }

        [Required(ErrorMessage = "Tou can't borrow nothing.")]
        public virtual Copy Copy { get; set; }

        [Required(ErrorMessage = "ReaderID is required")]
        public int ReaderID { get; set; }
        [ForeignKey("ReaderID")]
        public Reader Reader { get; set; }
     
        [Column("Date of taking")]
        public DateTime DateOfTaking { get; set; }
        [Column("Date of bakc (expected)")]
        public DateTime DateOfBack_Expected { get; set; }
        [Column("Date of back")]
        public DateTime? DateOfBack { get; set; }

    }
}

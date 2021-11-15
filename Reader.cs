using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library
{
    public class Reader
    {
        public int ReaderID { get; set; }

        [Required(ErrorMessage ="Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "IDNumber is required.")]
        public string IDNumber { get; set; }
     
        public int Fees { get; set; }

        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public virtual ICollection<Borrowing> Borrowings { get; set; }
    }
}

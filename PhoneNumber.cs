using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library
{
    public class PhoneNumber
    {
        public int PhoneNumberID { get; set; }
        public string Number { get; set; }
     
        public int ReaderID { get; set; }
        [ForeignKey("ReaderID")]
        [Required(ErrorMessage = "ReaderID is required")]
        public virtual Reader Reader {get; set;}
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Topic
    {
        public int TopicID { get; set; }
        public string Name { get; set; }
     
        public virtual ICollection<Book> Books { get; set; }
    }
}

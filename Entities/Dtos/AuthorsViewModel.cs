using Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class AuthorsViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }        
        public List<Book> Books { get; set; }

    }
}

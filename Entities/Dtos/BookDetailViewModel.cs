using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
   public class BookDetailViewModel
    {      
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }   
    }
}

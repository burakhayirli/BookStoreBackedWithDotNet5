using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}

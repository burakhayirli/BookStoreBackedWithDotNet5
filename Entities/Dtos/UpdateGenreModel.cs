using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class UpdateGenreModel
    {
        public String Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

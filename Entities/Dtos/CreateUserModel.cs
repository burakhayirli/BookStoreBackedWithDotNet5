using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class CreateUserModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
    }
}

using Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class Book 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public Genre Genre{ get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public int AuthorId { get; set; }
        [JsonIgnore]
        public Author Author { get; set; }


    }
}

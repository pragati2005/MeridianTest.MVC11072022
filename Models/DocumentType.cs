using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Meridian.Example.MVC.Models
{
    public class DocumentType
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public string name { get; set; }
        public string? location { get; set; }
    }
}

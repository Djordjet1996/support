using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupportSystemApp.Models
{
    public class Message
    {   [Key]
        public int id { get; set; }

        public string Name { get; set; }

        public DateTime Time { get; set; }

        public string Content { get; set; }
    }
}
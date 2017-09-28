using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class DepModel
    {
        [Key]
        public int DepId { get; set; }
        public string DepName { get; set; }

    }
}
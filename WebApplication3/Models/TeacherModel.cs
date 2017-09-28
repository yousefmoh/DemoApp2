﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class TeacherModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int ClassName { get; set; }

        [ForeignKey("ClassName")]
        public StdClass Class { get; set; }

    }
}
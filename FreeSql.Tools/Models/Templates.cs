﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeSqlTools.Models
{
    public  class Templates
    {
        [FreeSql.DataAnnotations.Column(IsPrimary = true)]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime AddTime { get; set; } = DateTime.Now;
        public DateTime EditTime { get; set; }

        [FreeSql.DataAnnotations.Column(DbType = "text")]
        public string Code { get; set; }
    }

 
    public class TemplatesOut
    {
       
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime AddTime { get; set; } = DateTime.Now;
        public DateTime EditTime { get; set; } 
    }
}

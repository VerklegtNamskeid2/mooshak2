using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.Entities
{
    public class Assignment
    {
        public int ID { get; set; }
        public int CoursesID { get; set; }
        public int Title { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.Entities
{
    public class Solution
    {
        public int ID { get; set; }
        public int userID { get; set; }
        public int milestoneID { get; set; }
        public string code { get; set; }

    }
}
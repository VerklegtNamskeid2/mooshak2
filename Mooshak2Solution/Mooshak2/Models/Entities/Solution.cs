using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.Entities
{
    public class Solution
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int MilestoneID { get; set; }
        public string Code { get; set; }

    }
}
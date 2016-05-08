using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshak2.Models.Entities
{
    public class MooshakUser
    {
        //Munum líklega ekki nota þennan gæja, en ætla að halda honum inni í smá tíma...
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
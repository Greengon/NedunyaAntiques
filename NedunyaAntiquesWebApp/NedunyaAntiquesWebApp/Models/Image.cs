using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NedunyaAntiquesWebApp.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }

        public virtual Product Product { get; set; }
    }
}
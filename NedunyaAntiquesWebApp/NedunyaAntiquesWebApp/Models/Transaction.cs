using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NedunyaAntiquesWebApp.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransId { get; set; }
        public int CustomerId { get; set; }
        public DateTime TransDate { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
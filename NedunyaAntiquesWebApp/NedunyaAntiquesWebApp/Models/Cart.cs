using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 This class is copied from
 https://github.com/shakeelosmani/MvcAffableBean/blob/master/MvcAffableBean/Models/Cart.cs
 TODO: work on it to adjust it to our project.

     */

namespace NedunyaAntiquesWebApp.Models
{
    public class Cart
    {
        /*
         * Note that Cart will be shown as many lines in the 
         * db with the same CartId.
         * When a user will request to see his Cart, we would search
         * the db for all the lines with the sesion CartId.
         * 
         */
        [Key]
        public int Id { get; set; }

        public string CartId { get; set; }

        public int ProductId { get; set; }
        public int Count { get; set; }
    
        
        public DateTime DateCreated { get; set; }

        public virtual Product Product { get; set; }


    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductMVC.Models
{
    public class Product
    {
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = " Please Enter Product Name")]
        [StringLength(10, MinimumLength = 3)]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = " Please Enter Brand Name")]
        [StringLength(10, MinimumLength = 3)]
        public string Brand { get; set; }


        [DataType(DataType.Text)]
        [Required(ErrorMessage = " Please Enter Quantity ")]
        [StringLength(10, MinimumLength = 1)]
        public string Quantity { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = " Please Enter Price")]
        [StringLength(10, MinimumLength = 1)]
        public string Price { get; set; }
    }
}
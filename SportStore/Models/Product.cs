using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SportStore.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage ="PLease enter a product name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "PLease enter a product description")]
        public string Description { get; set; }

        [Required]
        [Range(0.01,double.MaxValue,ErrorMessage = "PLease enter a positive price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "PLease specify a category")]
        public string Category { get; set; }

    }
}

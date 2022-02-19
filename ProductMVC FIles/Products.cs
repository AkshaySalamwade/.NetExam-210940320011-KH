using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductMVC011KH.Models
{
    public class Products
    {
                //ProductId int - Primary Key,
                // ProductName varchar(50),
                //  Rate Decimal(18,2),
                //Description varchar(200),
                //CategoryName varchar(50),
     

         [Key]
         [Display(Name ="Product ID")]
         public int ProductId { get; set; }


        [Display(Name = "Product Name")]
        [Required(ErrorMessage ="please Enter the Product Name")]
        public string ProductName { get; set; }


        [Display(Name = " Rate")]
        [Required(ErrorMessage = "please Enter rate")]
        public decimal Rate { get; set; }

        [Display(Name = "Product Description")]
        [Required(ErrorMessage = "please Enter the Description")]
        public string Description { get; set; }

        [Display(Name = "Categotry Name")]
        [Required(ErrorMessage = "please Enter the Category")]
        public string CategoryName { get; set; }



    }
}
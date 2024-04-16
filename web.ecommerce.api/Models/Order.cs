using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using web.ecommerce.api.CustomValidators;

namespace web.ecommerce.api.Models
{
    public class Order
    {
        [BindNever]
        public int? OrderNo { get; set; }
        [DateValidator(ErrorMessage = "")]
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "{0} needs to be provided")]
        [InvoicePriceValidationAttibute]
        public double InvoicePrice { get; set; }
        [Required(ErrorMessage = "{0} needs to be provided")]
        public List<Product> Products { get; set; }  = new List<Product>();

        public override string ToString()
        {
            string productsString = string.Empty;
            foreach (var item in Products)
            {
                productsString += item.ToString() + "\n";
            }
            return ($"OrderNoº:{this.OrderNo}\n" +
                $"OrderDate:{this.OrderDate}\n" +
                $"InvoicePrice{this.InvoicePrice}\n" +
                $"Products:{productsString}");
        }

    }
}

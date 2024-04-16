using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using web.ecommerce.api.Models;

namespace web.ecommerce.api.CustomValidators
{
    public class InvoicePriceValidationAttibute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var order = (Order)validationContext.ObjectInstance;
            if(value == null) 
            {
                return new ValidationResult("Invoice price can't be blank!");
            } else if (order.Products.Any())
            {
                string errorPriceMessage = string.Empty;
                List<string> sumProds = new List<string>();
                double sum = 0;
                double invoicePrice = (double)value;
                for (int i = 0; i<order.Products.Count; i++)
                {
                    Product product = order.Products[i];
                    double prodSum = product.Price * product.Quantity;
                    sumProds.Add(prodSum.ToString());
                    errorPriceMessage += $"Price is {product.Price}; Quantity is {product.Quantity}; so total cost of this product is {product.Price} * {product.Quantity} = {prodSum} \n";
                    sum += prodSum;
                }

                if ((invoicePrice - sum) < 0)
                {
                    return new ValidationResult($"Invoice price incorrect, the total cost of the products is {sum} = {string.Join('+',sumProds)}\n" + errorPriceMessage, new[] { validationContext.MemberName });
                }
                return ValidationResult.Success;
            }
            else return ValidationResult.Success;
        }
    }
}
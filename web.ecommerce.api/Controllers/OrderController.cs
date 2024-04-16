using Microsoft.AspNetCore.Mvc;
using web.ecommerce.api.Models;

namespace web.ecommerce.api.Controllers
{
    public class OrderController : Controller
    {
        [Route("/order")]
        public IActionResult Post(Order order)
        {
            if(!ModelState.IsValid) 
            {
                List<string> errorList = new List<string>();
                foreach(var value in ModelState.Values) 
                {
                    foreach (var error in value.Errors)
                    {
                        errorList.Add(error.ErrorMessage);
                    }
                }
                string errors = string.Join("\n", errorList);
                return BadRequest(errors);
            }
            Random rnd = new Random();
            return Content($"Order Number{rnd.Next(0, 99999)}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using Test_3.Models;

namespace Test_3.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        public Product[] products = new Product[]
        {
            new Product {Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1},
            new Product {Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M},
            new Product {Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M}
        };
     


        [HttpGet]
        [Route("getProduct/{id}")]
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet]
        [Route("getCurrency")]
        public async Task<IHttpActionResult> GetCurrency()
        {
            string accesskey = "cf6927fe016675b34a838c8208f98144";
            string currency = "RUB";
            string host = "apilayer.net";

            string uri = $"http://{host}/api/live?access_key={accesskey}&currencies={currency}";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync(uri);
                var responseString = await response.Content.ReadAsStringAsync();
                var currencyModel = JsonConvert.DeserializeObject<CurrencyModel>(responseString);
                return Json(currencyModel.quotes.USDRUB);
            }

        }
    }
}

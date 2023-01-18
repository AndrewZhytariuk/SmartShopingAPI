using SmartShoping.Domain.Models;
using System.Web.Http;
using SmartShoping.BusinessLogic.Interfaces;
using SmartShoping.BusinessLogic;
using SmartShoping.BusinessLogic.Services;
using System;

namespace SmartShopingAPI.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private readonly IProductService _productService = new ProductService(new ContextDB());
        ProductsController() { }

        public ProductsController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(_productService.GetAll());
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(_productService.Get(id));
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] Product product)
        {
            if (string.IsNullOrEmpty(product.Name))
                return Ok("Can`t be empty");

            _productService.Add(product);

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] Product product)
        {
            _productService.Update(product);

            return Ok();
        }

        [HttpGet]
        [Route("search/{name}")]
        public IHttpActionResult Search(string name)
        {
            return Ok(_productService.Search(name));
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {

            return Ok();
        }
    }
}
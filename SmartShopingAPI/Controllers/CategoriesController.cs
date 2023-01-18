using SmartShoping.BusinessLogic.Interfaces;
using SmartShoping.Domain.Models;
using System.Linq;
using System.Web.Http;
using SmartShoping.BusinessLogic;
using System;
using SmartShoping.BusinessLogic.Services;

namespace SmartShopingAPI.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController()
        {
            _categoryService = new CategoryService(new ContextDB());
        }

        public CategoriesController(ICategoryService categoryService)
        {
            this._categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService)); ;

        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(_categoryService.GetAll());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(_categoryService.Get(id));
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] Category category)
        {

            if (string.IsNullOrEmpty(category.Name))
                return Ok("Can`t be empty");

            _categoryService.Add(category);

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] Category category)
        {

            _categoryService.Update(category);

            return Ok();
        }

        [HttpGet]
        [Route("search/{name}")]
        public IHttpActionResult Search(string name)
        {
            return Ok(_categoryService.Search(name));
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _categoryService.Delete(id);

            return Ok();
        }
    }
}

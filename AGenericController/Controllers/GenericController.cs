using AGenericController.Models;
using AGenericController.Models.Contexts;
using System.Web.Mvc;

namespace AGenericController.Controllers
{
    public class GenericController<T> : Controller where T: class
    {
        private GenericLayer<T> layer = new GenericLayer<T>();

        [HttpGet]
        public ActionResult GetAll()
        {
            using (layer)
            {
                return new Result() { Value = layer.GetAll() };
            }
                
        }

        [HttpGet]
        public ActionResult GetById(object id)
        {
            return new Result() { Value = layer.GetById(id) };
        }
        [HttpPost]
        public ActionResult Create(T element)
        {
            return new Result() { Value = layer.Create(element) };
        }
        [HttpPost]
        public ActionResult Update(T element)
        {
            return new Result() { Value = layer.Update(element)  };
        }
        [HttpPost]
        public ActionResult Delete(T element)
        {
            return new Result() { Value = layer.Delete(element) };
        }
    }
}
using Newtonsoft.Json;
using System.Web.Mvc;

namespace AGenericController.Models
{
    public class Result : ActionResult
    {
        public string ContentType { set; get; }
        public object Value { get; set; }

        public Result()
        {
            ContentType = "application/json";
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.StatusCode = 418;
            context.HttpContext.Response.ContentType = ContentType;
            if (Value.GetType().IsClass)
            {
                context.HttpContext.Response.Write(JsonConvert.SerializeObject(Value));
            }
            else
            {
                context.HttpContext.Response.Write(Value);
            }

        }
    }
}
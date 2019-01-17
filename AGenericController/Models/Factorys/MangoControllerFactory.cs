using AGenericController.Controllers;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace AGenericController.Models.Factorys
{
    public class MangoControllerFactory: DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (requestContext.HttpContext.Request.RawUrl.StartsWith("/api/"))
            {
                var genericController = typeof(GenericController<>);
                return Activator.CreateInstance(genericController.MakeGenericType(Type.GetType("AGenericController.Models.Contexts." + controllerName))) as IController;
            }
            return base.CreateController(requestContext, controllerName);
        }
    }
}
using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;

namespace Samson.Mvc.Ninject
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        protected IKernel Kernel { get; set; }

        public NinjectControllerFactory(IKernel kernel)
        {
            Kernel = kernel;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return Kernel.Get(controllerType) as Controller;
        }
    }
}
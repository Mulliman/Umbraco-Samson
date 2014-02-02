using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Ninject;

namespace Samson.Mvc.Ninject
{
    public class NinjectWebApiControllerFactory : IHttpControllerActivator
    {
        protected IKernel Kernel { get; set; }

        public NinjectWebApiControllerFactory(IKernel kernel)
        {
            Kernel = kernel;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var controller = (IHttpController) Kernel.Get(controllerType);

            request.RegisterForDispose(new Release(() => Kernel.Release(controller)));

            return controller;
        }

        private class Release : IDisposable
        {
            private readonly Action release;

            public Release(Action release)
            {
                this.release = release;
            }

            public void Dispose()
            {
                this.release();
            }
        }
    }
}

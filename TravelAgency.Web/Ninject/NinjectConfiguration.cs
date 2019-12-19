using Ninject;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelAgency.Web.Ninject
{
    public static class NinjectConfiguration
    {
        public static void Configure()
        {
            var kernel = new StandardKernel(new Module());
            kernel.Unbind<ModelValidatorProvider>();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
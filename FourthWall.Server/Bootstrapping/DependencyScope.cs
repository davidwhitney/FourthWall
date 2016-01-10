using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Activation.Blocks;

namespace FourthWall.Server.Bootstrapping
{
    public class DependencyScope : IDependencyScope
    {
        private readonly IActivationBlock _childContainer;

        public DependencyScope(IActivationBlock childContainer)
        {
            _childContainer = childContainer;
        }

        public void Dispose()
        {
            _childContainer.Dispose();
        }

        public object GetService(Type serviceType)
        {
            return _childContainer.Get(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _childContainer.GetAll(serviceType);
        }
    }
}
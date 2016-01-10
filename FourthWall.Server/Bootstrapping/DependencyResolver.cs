using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Activation.Blocks;

namespace FourthWall.Server.Bootstrapping
{
    public class DependencyResolver : IDependencyResolver
    {
        private readonly IKernel _container;

        public DependencyResolver(IKernel container)
        {
            _container = container;
        }

        public void Dispose()
        {
        }

        public IDependencyScope BeginScope()
        {
            return new DependencyScope(_container.BeginBlock());
        }

        public object GetService(Type serviceType)
        {
            return _container.TryGet(serviceType);
        }

        public IEnumerable GetServices(Type serviceType)
        {
            return _container.GetAll(serviceType);
        }

        IEnumerable<object> IDependencyScope.GetServices(Type serviceType)
        {
            return _container.GetAll(serviceType);
        }
    }

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
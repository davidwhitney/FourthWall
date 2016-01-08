using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Ninject;

namespace FourthWall.Server
{
    public class DependencyResolver : IDependencyResolver
    {
        private readonly StandardKernel _container;

        public DependencyResolver(StandardKernel container)
        {
            _container = container;
        }

        public void Dispose()
        {
        }

        public IDependencyScope BeginScope()
        {
            throw new System.NotImplementedException();
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
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Compilation;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;

namespace Glass.Mvp
{
    public class CastleDependencyResolver : IDependencyResolver
    {
        private static IWindsorContainer _container;

        public static readonly object _lock = new object();

        public CastleDependencyResolver()
        {
            Setup();            
        }

        public void Setup()
        {
            if(_container == null)
            {
                lock(_lock)
                {
                    if(_container == null)
                    {
                        SetupContainer();
                    }
                }
            }
        }

        private void SetupContainer()
        {
            _container = new WindsorContainer(new XmlInterpreter());
            _container.Register(
                Component.For<IDependencyResolver>().ImplementedBy<CastleDependencyResolver>()
                );

            var assemblies = BuildManager.GetReferencedAssemblies();

            foreach (Assembly assembly in assemblies)
            {
                AllTypes.FromAssembly(assembly).BasedOn<Presenter>();
            }
        }

        public T Resolve<T>(IDictionary args = null)
        {
            return _container.Resolve<T>(args);
        }

        public IEnumerable<T> ResolveServices<T>()
        {
            return _container.ResolveAll<T>();
        }
        public object Resolve(Type type, IDictionary args = null)
        {
            return _container.Resolve(type, args);
        }
    }
}

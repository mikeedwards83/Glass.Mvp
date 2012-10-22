using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;

namespace Glass.Mvp
{
    public class CastleDependencyResolver : IDependencyResolver
    {
        private IWindsorContainer _container;

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
                        _container = new WindsorContainer(new XmlInterpreter()                            );
                    }
                }
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
    }
}

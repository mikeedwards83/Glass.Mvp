using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glass.Mvp
{
    public interface IDependencyResolver
    {
        T Resolve<T>(IDictionary args = null);

        IEnumerable<T> ResolveServices<T>();
    }
}

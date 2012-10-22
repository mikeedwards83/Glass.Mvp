using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Glass.Mvp
{
    public static  class Utilities
    {
        /// <summary>
        /// Crates a instance of an object. Must have a parameterless constructor
        /// </summary>
        /// <param name="type"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static object CreateInstance(Type type)
        {
            string name = type.FullName;
            
            return type.Assembly.CreateInstance(name);
        }
        public static T CreateInstance<T>(Type type)
        {
            return (T) CreateInstance(type);
        }
    }
}

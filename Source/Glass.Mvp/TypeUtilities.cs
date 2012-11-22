using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Compilation;

namespace Glass.Mvp
{
    public static class TypeUtilities
    {
        private static IEnumerable<Type> _types;

        public static IEnumerable<Type> GetTypes(Func<Type,bool> predicate )
        {
            var types = GetTypesInAssemblies();


            var results = types.Where(x => x.FullName.Contains("Glass"));
            var r1 = types.Where(x => typeof (Presenter).IsAssignableFrom(x));

            return types.Where(predicate);

        }

        //Take from System.Web.Mvc.TypeCacheUtil
        public  static IEnumerable<Type> GetTypesInAssemblies()
        {

            if (_types == null)
            {
                // Go through all assemblies referenced by the application and search for types matching a predicate
                IEnumerable<Type> typesSoFar = Type.EmptyTypes;

                ICollection assemblies = BuildManager.GetReferencedAssemblies();
                foreach (Assembly assembly in assemblies)
                {
                    Type[] typesInAsm;
                    try
                    {
                        typesInAsm = assembly.GetTypes();
                    }
                    catch (ReflectionTypeLoadException ex)
                    {
                        typesInAsm = ex.Types;
                    }
                    typesSoFar = typesSoFar.Concat(typesInAsm);
                }
                _types = typesSoFar;
            }
            return _types;


        }
    }
}

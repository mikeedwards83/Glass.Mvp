using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Glass.Mvp.Views;

namespace Glass.Mvp
{
    public static class MvpGlobal
    {

        public static  IDependencyResolver DependencyResolver { get; set; }

        static MvpGlobal()
        {

            ConfigureViews();

            DependencyResolver= new CastleDependencyResolver();

        }

        private static void ConfigureViews()
        {
            

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glass.Mvp.Views
{
    public class RazorView: AbstractView
    {
        public RazorView()
        {
            Extension = "cshtml";
        }

        public override void Execute(System.Web.HttpResponse response)
        {
            response.Write("cshtml");
        }
    }

}

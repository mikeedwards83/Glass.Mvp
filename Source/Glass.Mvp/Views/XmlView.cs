using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glass.Mvp.Views
{
    public class XmlView : AbstractView
    {
        public XmlView()
        {
            Extension = "xml";
        }

        public override void Execute(System.Web.HttpResponse response)
        {
            response.Write("xml");
        }
    }
}

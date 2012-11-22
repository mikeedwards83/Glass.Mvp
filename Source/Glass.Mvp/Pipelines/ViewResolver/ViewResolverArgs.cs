using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Glass.Mvp.Views;
using System.Web;

namespace Glass.Mvp.Pipelines.ViewResolver
{
    public class ViewResolverArgs : AbstractPipelineArgs
    {
        public AbstractView Result { get; set; }

        public HttpContext Context { get; set; }

        public IEnumerable<AbstractView> Views { get; set; } 

        public ViewResolverArgs(HttpContext context, IEnumerable<AbstractView> views )
        {
            Views= views;
            Context = context;
        }
    }
}

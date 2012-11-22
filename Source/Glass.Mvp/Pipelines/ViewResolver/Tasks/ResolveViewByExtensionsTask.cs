using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glass.Mvp.Pipelines.ViewResolver.Tasks
{
    public class ResolveViewByExtensionsTask :IViewResolverTask
    {
        public void Execute(ViewResolverArgs args)
        {
            if (args.Result != null)
                return;

            var context = args.Context;

            foreach (var view in args.Views)
            {
                var finalView = ResolveViewByUrlExtensionTask.GetViewFile(context, view);
                if (finalView != null)
                {
                    args.Result = finalView;
                    break;
                }
            }
        }
    }
}

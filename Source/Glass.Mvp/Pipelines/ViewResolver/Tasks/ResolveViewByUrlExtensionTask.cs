using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Glass.Mvp.Views;

namespace Glass.Mvp.Pipelines.ViewResolver.Tasks
{
    public class ResolveViewByUrlExtensionTask : IViewResolverTask
    {
        public void Execute(ViewResolverArgs args)
        {
            var context = args.Context;
            var urlPath = context.Request.Url.AbsolutePath;

            if (!args.Views.Any(x => urlPath.EndsWith(x.Extension)))
            {
                args.Result = null;
            }
            else
            {
                var view = args.Views.First(x => urlPath.EndsWith(x.Extension));
                args.Result = GetViewFile(context, view);
            }
        }

        public static AbstractView GetViewFile(HttpContext context, AbstractView view)
        {
            var extension = view.Extension;
                
            string url = context.Request.Url.AbsolutePath;

            if (url.EndsWith("/"))
                url = url + "index";

            if (!url.EndsWith("." + extension))
                url = url + "." + extension;

            url = "/views" + url;

            FilePath path = context.Server.MapPath(url);

            if (File.Exists(path))
            {
                var stream = File.OpenRead(path);
                view.File = stream;
                view.Path = path;
                return view;
            }
            else return null;
        }
    }
}

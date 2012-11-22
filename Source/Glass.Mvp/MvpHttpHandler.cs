using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;
using System.Web.SessionState;
using Glass.Mvp.Pipelines.ViewResolver;
using Glass.Mvp.Views;

namespace Glass.Mvp
{
    public class MvpHttpHandler : IHttpAsyncHandler, IHttpHandler, IRequiresSessionState
    {
        public RequestContext RequestContext { get; private set; }

        public MvpHttpHandler(RequestContext requestContext)
        {
            RequestContext = requestContext;
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("hello {0}".Formatted(context.Request.Url));
        }

        public bool IsReusable { get; private set; }

        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
        {
            //TODO: resolve how I handle this, this needs to be Async

            var view = ResolveView(context, MvpGlobal.DependencyResolver);

            if (view != null)
            {
                view.Execute(context.Response);
            }
            else
            {
                throw new HttpException(404, "File not found");
            }

            MvpAsyncResult result = new MvpAsyncResult(true,extraData,true, null);
            return result;
        }

        public void EndProcessRequest(IAsyncResult result)
        {
            
        }

        public AbstractView ResolveView(HttpContext context, IDependencyResolver resolver)
        {
            var viewResolver =resolver.Resolve<ViewResolverPipeline>();
            var views = resolver.ResolveServices<AbstractView>();

            var args = new ViewResolverArgs(context, views);
            viewResolver.Run(args);

            return args.Result;
        }

        

    }
}

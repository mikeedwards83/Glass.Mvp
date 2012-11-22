using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Compilation;

namespace Glass.Mvp.Pipelines.PresenterResolver.Tasks
{
    public class PresenterResolverStandard : IPresenterResolverTask
    {
        private readonly IDependencyResolver _resolver;
        public const string ViewsFolder = "\\views";
        public const string ViewsNamespace = ".Views";
        

        public PresenterResolverStandard(IDependencyResolver resolver)
        {
            _resolver = resolver;
        }

        public void Execute(PresenterResolverArgs args)
        {

            var viewSection = args.FilePath.ToLower().SplitAfter(ViewsFolder);


            string typeEnd = ViewsNamespace +
                            viewSection.RemoveExtension().ToString().Replace("\\", ".");

            var presenterType = typeof (Presenter);

            var types = TypeUtilities.GetTypes(
                x =>// presenterType.IsAssignableFrom(x)
                      x.FullName.ToLowerInvariant().EndsWith(typeEnd));

            var allTypes = TypeUtilities.GetTypes(x => true);


            if(types.Count() > 1)
            {
                throw new ApplicationException("Can't work out which presenter to use");
            }
            else if(types.Any())
            {
                var presenter = _resolver.Resolve(types.First()) as Presenter;
                args.Result = presenter;
            }
            else
            {
                throw new ApplicationException("Presenter not found");
            }

        }


    }
}

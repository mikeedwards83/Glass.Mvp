using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Glass.Mvp.Pipelines.PresenterResolver;

namespace Glass.Mvp.Views
{
    public class RazorView: AbstractView
    {
        private readonly PresenterResolverPipeline _presenterResolver;

        public RazorView(PresenterResolverPipeline presenterResolver)
        {
            _presenterResolver = presenterResolver;
            Extension = "cshtml";
        }

        public override void Execute(System.Web.HttpResponse response)
        {
            var data = new byte[File.Length];
            
            //TODO: very long files will blow up here
            File.Read(data, 0, (int)File.Length);

            string template = Encoding.UTF8.GetString(data);

            var presenter = RunPresenter(Path);

            var result = RazorEngine.Razor.Parse(template, new {name = presenter.GetType().Name});

            response.Write(result);
        }


        public Presenter RunPresenter(FilePath path)
        {
            PresenterResolverArgs args =new PresenterResolverArgs(path);
            _presenterResolver.Run(args);
            return args.Result;
        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glass.Mvp.Pipelines.ViewResolver
{
    public class ViewResolverPipeline : AbstractPipelineRunner<ViewResolverArgs, IViewResolverTask>
    {
        public ViewResolverPipeline(IEnumerable<IViewResolverTask> tasks):base(tasks)
        {

        }
    }
}

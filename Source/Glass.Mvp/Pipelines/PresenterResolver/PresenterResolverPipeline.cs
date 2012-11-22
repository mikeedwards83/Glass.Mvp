using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glass.Mvp.Pipelines.PresenterResolver
{
    public class PresenterResolverPipeline : AbstractPipelineRunner<PresenterResolverArgs, IPresenterResolverTask>
    {
        public PresenterResolverPipeline(IEnumerable<IPresenterResolverTask> tasks):base(tasks)
        {
        }
    }
}

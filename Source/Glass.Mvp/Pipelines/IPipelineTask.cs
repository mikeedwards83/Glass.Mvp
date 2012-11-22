using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glass.Mvp.Pipelines
{
    public interface IPipelineTask<T> where T : AbstractPipelineArgs
    {
        void Execute(T args);
    }
}

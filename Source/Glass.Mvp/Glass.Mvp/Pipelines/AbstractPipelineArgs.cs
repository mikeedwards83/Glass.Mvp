using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glass.Mvp.Pipelines
{
    public abstract class AbstractPipelineArgs
    {

        public bool IsAborted { get; private set; }

        public AbstractPipelineArgs()
        {
        }

        public bool AbortPipeline()
        {
            IsAborted = true;
            return IsAborted;
        }


    }
}

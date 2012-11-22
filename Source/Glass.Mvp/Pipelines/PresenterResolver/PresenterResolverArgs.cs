using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Glass.Mvp.Pipelines.PresenterResolver
{
    public class PresenterResolverArgs : AbstractPipelineArgs
    {
        public PresenterResolverArgs(FilePath filePath)
        {
            FilePath = filePath;
        }

        public FilePath FilePath { get; set; }

        public Presenter Result { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glass.Mvp.Pipelines
{
    public abstract class AbstractPipelineRunner<T, K>
        where T : AbstractPipelineArgs
        where K : IPipelineTask<T>
    {
        IEnumerable<K> _tasks;

        public IEnumerable<K> Tasks { get { return _tasks; } }


        public AbstractPipelineRunner(IEnumerable<K> tasks)
        {
            _tasks = tasks;
        }

        /// <summary>
        /// Runs a pipeline and returns the resultant arguments
        /// </summary>
        /// <returns></returns>
        public virtual T Run(T args)
        {
            if (_tasks != null)
            {
                foreach (var task in _tasks)
                {
                    task.Execute(args);
                    if (args.IsAborted)
                        break;
                }
            }

            return args;
        }



        

    }
}

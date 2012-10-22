using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Glass.Mvp.Views
{
    public abstract class AbstractView 
    {
        public string Extension { get; set; }

        public FileStream File { get; set; }

        public abstract void Execute(HttpResponse response);
    }
}

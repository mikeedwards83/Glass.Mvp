using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Glass.Mvp
{
    public class FilePath
    {
        private readonly string _path;

        public FilePath(string path)
        {
            _path = path.ToLower();
        }

        public string Extension
        {
            get { return Path.GetExtension(_path); }
        }

        public string FileName
        {
            get { return Path.GetFileName(_path); }
        }

        public FilePath AddExtension(string extension)
        {
            return new FilePath(_path + "." + extension);
        }
        public FilePath PrefixPath(string prefix)
        {
            return new FilePath(prefix + _path);
        }

        public FilePath ChangeExtension(string newExtension)
        {
            return new FilePath(Path.ChangeExtension(_path, newExtension));
        }

        
        public FilePath SplitAfter(string split)
        {
            var last = _path.Split(new[] {split}, StringSplitOptions.RemoveEmptyEntries).Last();
            return new FilePath(last);
        }

        public FilePath RemoveExtension()
        {
            string path = Path.ChangeExtension(_path, string.Empty);
            return new FilePath(path.Substring(0, path.Length - 1));
        }



        public override string ToString()
        {
            return _path;
        }

        public FilePath ToLower()
        {
            return new FilePath(_path.ToLowerInvariant());
        }


        public static implicit operator string (FilePath path)
        {
            return path._path;
        }

        public static implicit operator FilePath(string path)
        {
            return new FilePath(path);
        }
    }
}


using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FamiliesUpdater
{
    public abstract class FilesExplorer
    {
        private readonly string _path = "";
        private List<string> _files = null;

        public bool GetSubFoldersFiles { private get; set; } = false;

        public FilesExplorer(string path) => _path = path;

        private bool IsFile => File.Exists(_path);
        private bool IsFolder => Directory.Exists(_path);

        protected List<string> Files
        {
            get
            {
                switch (IsFile)
                {
                    case true when !IsFolder:
                        _files = new List<string>()
                        {
                            _path
                        };
                        break;
                    case false when IsFolder:
                        _files = GetFolderFiles();
                        break;
                    default:
                        break;
                }

                return _files;
            }
        }

        private List<string> GetFolderFiles()
        {
            var mode = GetSubFoldersFiles ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            return Directory.GetFiles(_path, "*", mode).ToList();
        }
    }
}

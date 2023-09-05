
using System.Collections.Generic;
using System.Linq;

namespace FamiliesUpdater
{
    internal class FamilesExplorer : FilesExplorer
    {
        private string[] _extensions = null;

        public bool IsCopy { private get; set; } = false;

        public FamilesExplorer(string path, params string[] extensions)
                  : base(path)
               => _extensions = extensions;       

        public List<FamilyFile> FamilyFiles
        {
            get
            {
                var familyFiles = new List<FamilyFile>();
                var files = Files.Where(f => _extensions.Any(ext => f.EndsWith(ext))).ToList();
                files.ForEach(f => familyFiles.Add(new FamilyFile(f, IsCopy)));
                return familyFiles;
            }
        }
    }
}
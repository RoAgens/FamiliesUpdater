
using System.Collections.Generic;
using System.Linq;

namespace FamiliesUpdater
{
    public class FamilesExplorer : FilesExplorer
    {
        private string[] _extensions = null;

        public bool IsCopy { get; set; } = false;

        public FamilesExplorer(string path, params string[] extensions) : base(path)
               => _extensions = extensions;

        public void LoadFamily()
        {
            foreach(FamilyFile familyFile in FamilyFiles)
            {
                if (!(familyFile.Load(IsCopy)))
                      familyFile.UpDate();
            }
        }

        private List<FamilyFile> FamilyFiles
        {
            get
            {
                var familyFiles = new List<FamilyFile>();
                var files = Files.Where(f => _extensions.Any(ext => f.EndsWith(ext))).ToList();
                files.ForEach(f => familyFiles.Add(new FamilyFile(f)));
                return familyFiles;
            }
        }
    }
}

        //public bool Load()
        //{
        //    if (IsFile)
        //    {

        //    }

        //    return Project.Doc.Do(LoadFamily);
        //}

        //private bool LoadFamily() => Project.Doc.LoadFamily(_familyPath);

        //public bool UpDate() => Project.Doc.Do(UpDateFamily);

        //private bool IsFile => File.Exists(_path);
    //}
//}

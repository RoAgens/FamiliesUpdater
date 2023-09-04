
using Autodesk.Revit.DB;
using FamiliesUpdater.Exeptions;
using System.IO;

namespace FamiliesUpdater
{
    internal class FamilyFile
    {
        private readonly string _familyPath;

        public FamilyFile(string familyPath) => _familyPath = familyPath;
        public string Version => _familyPath.GetRevitFileVersion();
        public bool Load(bool IsCopy)
        {
            if (IsCopy) Copy();
            return Project.Doc.Do(LoadFamily);
        }
        public bool UpDate() => Project.Doc.Do(UpDateFamily);
        private bool LoadFamily() => IsFile ? Project.Doc.LoadFamily(_familyPath) : false;
        private void Copy()
        {
            string newFolderName = Path.Combine(Path.GetDirectoryName(_familyPath), "Original");

            if (IsFile)
            {
                string folderName = Path.GetDirectoryName(_familyPath);
                 if (!Directory.Exists(newFolderName))
                      Directory.CreateDirectory(newFolderName);
            }

             File.Copy(_familyPath, Path.Combine(newFolderName, Path.GetFileName(_familyPath)), true); 
        }
        private bool UpDateFamily()
            => IsFile
            ? !(Project.App.OpenDocumentFile(ModelPathUtils.ConvertUserVisiblePathToModelPath(_familyPath), new OpenOptions()) is null)
            : false;
        private bool IsFile => File.Exists(_familyPath);
    }
}
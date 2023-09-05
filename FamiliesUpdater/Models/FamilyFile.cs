
using Autodesk.Revit.DB;
using FamiliesUpdater.Exeptions;
using System.IO;

namespace FamiliesUpdater
{
    internal class FamilyFile
    {
        private const string copyFolderName = "Original";
        private readonly string _familyPath;
        private bool _isCopy;

        public string FamilyPath => _familyPath;

        public FamilyFile(string familyPath, bool isCopy = false)
        {
            _familyPath = familyPath;
            _isCopy = isCopy;
        }
        public string Version => _familyPath.GetRevitFileVersion();

        public void LoadUpDate()
        {
            var file = Directory.GetParent(_familyPath).Name;
            if (file != copyFolderName)
                if (!(LoadFamily())) UpDateFamily();
        }

        private bool LoadFamily()
        {
            var iSLoaded = Project.Doc.LoadFamily(_familyPath);
            if (iSLoaded && _isCopy) Copy();

            return iSLoaded;
        }

        public bool UpDateFamily()
        {
            return !(Project.App.OpenDocumentFile(ModelPathUtils.ConvertUserVisiblePathToModelPath(_familyPath),
                                                  new OpenOptions()) is null);
        }

        private void Copy()
        {
            string newFolderName = Path.Combine(Path.GetDirectoryName(_familyPath), copyFolderName);

            if (IsFile)
            {
                string folderName = Path.GetDirectoryName(_familyPath);
                 if (!Directory.Exists(newFolderName))
                      Directory.CreateDirectory(newFolderName);
            }

             File.Copy(_familyPath, Path.Combine(newFolderName, Path.GetFileName(_familyPath)), true); 
        }

        private bool IsFile => File.Exists(_familyPath);
    }
}

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace FamiliesUpdater
{
    internal class FamilesExplorer : FilesExplorer
    {
        private string[] _extensions = null;

        public bool IsCopy { get; set; } = false;
        //public FamilesExplorer()
        //{

        //}

        public FamilesExplorer(string path, params string[] extensions) : base(path)
               => _extensions = extensions;

        public void LoadFamily()
        {
            //try
            //{
            //    using (var tx = new Transaction(doc, $"{func.Method.Name}"))
            //    {
            //        if (tx.Start() == TransactionStatus.Started)
            //        {
            //            foreach (FamilyFile familyFile in FamilyFiles)
            //            {
            //                Project.Doc.LoadFamily(familyFile.);
            //            }

            //            tx.Commit();
            //        }
            //    }
            //}
            //catch
            //{

            //}

            //using (Transaction trans = new Transaction(Project.Doc, "Load Family"))
            //{
            //    trans.Start();

            //    //FamilySymbol familySymbol = null;

            //    try
            //    {
            //        foreach (FamilyFile familyFile in FamilyFiles)
            //        {
            //            Project.Doc.LoadFamily(familyFile.FamilyPath);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        // Обработка других ошибок
            //        //TaskDialog.Show("Error", ex.Message);
            //        //return false;
            //    }

            //    trans.Commit();
            //}

            foreach (FamilyFile familyFile in FamilyFiles)
            {
                try
                {
                    Project.Doc.LoadFamily(familyFile.FamilyPath);
                }
                catch (Exception ex)
                {
    
                }
            }
        }


                //foreach (FamilyFile familyFile in FamilyFiles)
                //{
                //    if (!(familyFile.Load(IsCopy)))
                //          familyFile.UpDate();
                //}
            //}

        public List<FamilyFile> FamilyFiles
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

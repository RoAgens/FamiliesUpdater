using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using FamiliesUpdater.ViewModels;

namespace FamiliesUpdater
{
    [Transaction(TransactionMode.Manual)]
    public class FamiliesUpdaterApp : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Project.Initialize(commandData);

            try
            {
                using (var t = new Transaction(Project.Doc, "Загрузка семейств"))
                {
                    t.Start();

                        var viewModel = new ViewModel();

                    foreach (FamilyFile familyFile in viewModel.FamilyFiles)
                                        familyFile.LoadUpDate();

                    t.Commit();
                }

                return Result.Succeeded;
            }

            catch
            {

            }

            return Result.Succeeded;
        }
    }
}

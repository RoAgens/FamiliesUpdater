using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using FamiliesUpdater.ViewModels;

namespace FamiliesUpdater
{
    [Transaction(TransactionMode.Manual)]
    public class Class1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {
            Project.Initialize(commandData);

            try
            {
                using (var t = new Transaction(Project.Doc, "Нумерация по сплайну"))
                {
                    t.Start();

                        var viewModel = new ViewModel();

                        foreach (FamilyFile familyFile in viewModel.FamilyFiles)
                        {
                            Project.Doc.LoadFamily(familyFile.FamilyPath);
                        }

                    t.Commit();
                }

                return Result.Succeeded;
            }

            catch
            {

            }

            //try
            //{
            //    using (var tx = new Transaction(Project.Doc, "UpDate"))
            //    {
            //        if (tx.Start() == TransactionStatus.Started)
            //        {
            //            var viewModels = new ViewModel();

            //            tx.Commit();
            //        }
            //    }
            //}
            //catch
            //{

            //}

            //_folderPath = @"E:\_REVIT+\__Фирмы\Elsen\";
            //_folderPath = @"E:\__РАБОТА\ButchUpgrader\FamiliesFolder\";
            //_folderPath = @"E:\_REVIT+";

            //_folderPath = @"E:\__РАБОТА\FamiliesUpdater\FamiliesFolder";

            //_familyPath = @"E:\__РАБОТА\FamiliesUpdater\FamiliesFolder\ABC-VAV-MP1.rfa";
            //_familyPath = @"E:\__РАБОТА\FamiliesUpdater\FamiliesFolder\ABC-VAV-MP2.rfa";
            //_familyPath = @"E:\__РАБОТА\FamiliesUpdater\FamiliesFolder\ABC-VAV-MP3.rfa";

            //var filesExplorer = new FamilesExplorer(_familyPath, "rfa", "rte");
            //filesExplorer.GetSubFoldersFiles = false;
            //filesExplorer.LoadFamily();
            //var files = filesExplorer.FamilyFiles();

            //string files1 = "";

            //var isLoad1 = new FamilyFile(_familyPath).Load(true);
            //new FamilyFile(_familyPath).Copy();
            //var isLoad2 = isLoad1 == true ? false : new FamilyFile(_familyPath).UpDate();

            //var openOptions = new OpenOptions();
            //var doc1 = Project.App.OpenDocumentFile(ModelPathUtils.ConvertUserVisiblePathToModelPath(_familyPath), openOptions);

            //IFamilyLoadOptions familyLoadOptions = null;
            //familyLoadOptions

            //using (Transaction tx = new Transaction(Project.Doc, "Load Family"))
            //{
            //    if (tx.Start() == TransactionStatus.Started)
            //    {
            //        //Project.Doc.LoadFamily(_familyPath);
            //        //Project.Doc.LoadFamily(_familyPath);

            //        FilteredElementCollector familyCollector = new FilteredElementCollector(Project.Doc);
            //        ICollection<Element> familyElements = familyCollector.OfClass(typeof(Family)).ToElements();


            //        tx.Commit();
            //    }
            //}

            //return Result.Succeeded;

            //var t1 = _folderPath.GetFolderFiles(false);
            //var t2 = _folderPath.GetFolderFiles(true);
            //string[] searchPatterns = new string[] { "*.txt", "*.jpg", "*.docx" };

            //List<string> files = Directory.GetFiles(_folderPath, "*.rfa").ToList();
            //List<string> files = Directory.GetFiles(_folderPath, "*.rte").ToList();
            //List<string> files = Directory.GetFiles(_folderPath, "*.rvt").ToList();

            //List<string> files = Directory.GetFiles(_folderPath, "*.rfa *.rte").ToList(); 

            //List<string> files = _folderPath.GetFolderFiles(false, "rfa");
            //var familyFiles = new List<FamilyFile>();

            //files.ForEach(f => familyFiles.Add(new FamilyFile(f)));

            //List<string> files = _folderPath.GetFolderFiles(true, "rfa");
            //List<string> files = _folderPath.GetFolderFiles(false, "rte");
            //List<string> files = _folderPath.GetFolderFiles(true, "rte");
            //List<string> files = _folderPath.GetFolderFiles(false, "rvt");
            //List<string> files = _folderPath.GetFolderFiles(true, "rvt");
            //List<string> files = _folderPath.GetFolderFiles(false, "rfa", "rte", "rvt");

            //var versions = new List<string>();

            //files.ForEach(f => versions.Add(f.GetRevitFileVersion()));

            //var UIApp = commandData?.Application;
            //var UIDoc = UIApp?.ActiveUIDocument;
            //var Doc = UIDoc?.Document;
            //var app = UIApp.Application;



            //var version = Project.Version;

            //var groupFiles = new List<FamilyFile>();

            //foreach (FamilyFile ff in familyFiles)
            //{
            //    if (ff.Version == version)
            //    {
            //        groupFiles.Add(ff);
            //    }
            //}

            //string str1 = "2025";
            //string str2 = "2024";

            ////int result = String.Compare(str1, str2, StringComparison.Ordinal);

            ////if (result < 0)
            ////{
            ////    //Console.WriteLine("Строка 2021 идет перед строкой 2020.");
            ////}
            ////else if (result > 0)
            ////{
            ////    //Console.WriteLine("Строка 2021 идет после строки 2020.");
            ////}
            ////else
            ////{
            ////    //Console.WriteLine("Строки 2021 и 2020 идентичны.");
            ////}

            //var groupFiles1 = familyFiles
            //    .OrderBy(ff => ff.Version)
            //    .GroupBy(ff => ff.Version)
            //    .ToList();

            //var t1111 = groupFiles1.Where(lst => lst.Key == version).ToList();

            //List<Document> docs = new List<Document>();
            //OpenOptions openOptions = new OpenOptions();

            //{
            //    Audit = true
            //};

            //openOptions.

            //t1.ForEach(pth => docs.Add(Project.App.OpenDocumentFile(ModelPathUtils.ConvertUserVisiblePathToModelPath(pth), openOptions)));

            // Получение текущего документа Revit
            //Document fDoc = commandData.Application.ActiveUIDocument.Document;

            //string fFilePath = @"E:\__РАБОТА\ButchUpgrader\FamiliesFolder\MVI_Фильтр_грубой_очистки (v.2020).rfa";
            //string fFilePath = @"E:\__РАБОТА\ButchUpgrader\FamiliesFolder\ABC-VAV-MP.rfa";

            //// Получение информации о файле RFA
            //var fileInfo = new FileInfo(fFilePath);
            //var tt1 = fileInfo.Attributes;
            //var tt2 = fileInfo.AppendText();
            ////var tt3 = fileInfo.;

            //var fileVersionInfo = FileVersionInfo.GetVersionInfo(fFilePath);
            ////var fileVersionInfo = FileVersionInfo.GetVersionInfo(fFilePath);

            //string fileVersion = fileVersionInfo.FileVersion;
            //string productVersion = fileVersionInfo.ProductVersion;

            ////var file = File.ReadAllText(fFilePath);
            //string content = null;

            //// Попробуем прочитать файл, обрабатывая возможную блокировку
            //try
            //{
            //    using (FileStream fileStream = File.Open(fFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            //    using (StreamReader reader = new StreamReader(fileStream))
            //    {
            //        content = reader.ReadToEnd();
            //        //Console.WriteLine("Содержимое файла: " + content);
            //    }
            //}
            //catch (IOException ex)
            //{
            //    //Console.WriteLine("Ошибка при чтении файла: " + ex.Message);
            //}

            //string searchString = "\0F\0o\0r\0m\0a\0t\0:";
            //int index = content.IndexOf(searchString);

            //string extractedWord = content.Substring(index + 15, 9);

            ////var ttt = content[9];
            //var ttt = fFilePath.GetRevitFileVersion();

            //string pattern = @"F\s+o\s+r\s+m\s+a\s+t\s+:\s+(\d{4})"; // Используем группу захвата для 4-значного числа

            //Match match = Regex.Match(content, pattern);

            //if (match.Success)
            //{
            //    //string capturedValue = match.Groups[1].Value; // Получаем значение из группы захвата
            //    //Console.WriteLine("Найдено совпадение:");
            //    //Console.WriteLine("Извлеченное значение: " + capturedValue);
            //}
            //else
            //{
            //    //Console.WriteLine("Совпадений не найдено.");
            //}

            //try
            //{
            //    // Создаем объект для чтения XML
            //    XmlDocument xmlDoc = new XmlDocument();

            //    // Загружаем XML из файла
            //    xmlDoc.LoadXml(content);
            //    //xmlDoc.

            //    // Получаем строковое представление XML
            //    string xmlContent = xmlDoc.InnerXml;

            //    // Выводим содержимое на консоль (или делайте с ним, что вам нужно)
            //    Console.WriteLine(xmlContent);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Произошла ошибка: " + ex.Message);
            //}


            //var t3 = docs[0].Application.VersionNumber;
            //var t4 = docs[0].Application.

            //ModelPath modelPath = ModelPathUtils.ConvertUserVisiblePathToModelPath(t1[1]);

            //var t2 = app.OpenDocumentFile(modelPath, new OpenOptions());

            return Result.Succeeded;
        }
    }
}

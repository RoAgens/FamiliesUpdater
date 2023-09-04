using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiliesUpdater
{
    public sealed class Project : IDisposable
    {
        private static Project _instance;
        private ExternalCommandData _commandData;

        private Project(ExternalCommandData commandData) => _commandData = commandData;

        public static void Initialize(ExternalCommandData commandData) => _instance = new Project(commandData);
        public static UIApplication UIApp => _instance?._commandData?.Application;
        public static UIDocument UIDoc => UIApp?.ActiveUIDocument;
        public static Document Doc => UIDoc?.Document;
        public static Application App => UIApp?.Application;
        public static string Version => App?.VersionNumber;
        public void Dispose() => _instance = null;
    }
}

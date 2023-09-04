using B.Revit.Common.UI;

namespace B.Revit.BatchUpgrader.Addin.ViewModels
{
    internal class ButchUpgraderViewModel : BaseViewModel
    {
        private bool isProjectUpdate;
        private bool isFamilyUpdate;
        private bool isTemplateUpdate;
        private bool isOverwriteFiles;
        private bool isCreateCopies;
        private bool isDeleteBackup;
        private bool isIncludeSubfolders;

        public bool IsProjectUpdate
        {
            get => isProjectUpdate;
            set
            {
                isProjectUpdate = value;
                OnPropertyChanged();
            }
        }
        public bool IsFamilyUpdate
        {
            get => isFamilyUpdate;
            set
            {
                isFamilyUpdate = value;
                OnPropertyChanged();
            }
        }
        public bool IsTemplateUpdate
        {
            get => isTemplateUpdate;
            set
            {
                isTemplateUpdate = value;
                OnPropertyChanged();
            }
        }
        public bool IsOverwriteFiles
        {
            get => isOverwriteFiles;
            set
            {
                isOverwriteFiles = value;
                OnPropertyChanged();
            }
        }
        public bool IsCreateCopies
        {
            get => isCreateCopies;
            set
            {
                isCreateCopies = value;
                OnPropertyChanged();
            }
        }
        public bool IsDeleteBackup
        {
            get => isDeleteBackup;
            set
            {
                isDeleteBackup = value;
                OnPropertyChanged();
            }
        }
        public bool IsIncludeSubfolders
        {
            get => isIncludeSubfolders;
            set
            {
                isIncludeSubfolders = value;
                OnPropertyChanged();
            }
        }


    }
}

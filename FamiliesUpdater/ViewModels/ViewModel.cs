
using FamiliesUpdater.Views;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace FamiliesUpdater.ViewModels
{
    internal class ViewModel : BaseViewModel
    {
        private bool isProjectUpdate;
        private bool isFamilyUpdate;
        private bool isTemplateUpdate;
        private bool isOverwriteFiles;
        private bool isCreateCopies;
        private bool isDeleteBackup;
        private bool isIncludeSubfolders;

        private RelayCommand _upDate;
        private string _selectedFolder;
        private MainWindow _mainWindow;

        public ViewModel()
        {
            _mainWindow = new MainWindow();
            _mainWindow.DataContext = this;
            _mainWindow.ShowDialog();
        }

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

        private RelayCommand _selectFolder;
        public RelayCommand SelectFolder => _selectFolder ??
            (_selectFolder = new RelayCommand(obj =>
            {
                var folderBrowserDialog = new FolderBrowserDialog();
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    _selectedFolder = folderBrowserDialog.SelectedPath;
                }
            }));

        public RelayCommand UpDate => _upDate ??
            (_upDate = new RelayCommand(obj =>
            {
                if (_selectedFolder != "")
                {
                    var model = new FamilesExplorer(_selectedFolder, GetExtensions())
                    {
                        IsCopy = IsCreateCopies,
                        GetSubFoldersFiles = IsIncludeSubfolders
                    };

                    FamilyFiles = model.FamilyFiles;
                    _mainWindow.Close();
                }
            }));

        private string[] GetExtensions()
        {
            var extensions = new List<string>();

            if (IsProjectUpdate) extensions.Add("rvt"); 
            if (IsFamilyUpdate) extensions.Add("rfa");
            if (IsTemplateUpdate) extensions.Add("rte");

            return extensions.ToArray();
        }

        public List<FamilyFile> FamilyFiles { get; private set; }
    }
}

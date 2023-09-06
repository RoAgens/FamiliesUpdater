
using FamiliesUpdater.Views;
using System.Windows.Forms;
using System.Collections.Generic;
using FamiliesUpdater.Properties;
using System.Collections.ObjectModel;
using System.Linq;

namespace FamiliesUpdater.ViewModels
{
    internal class ViewModel : BaseViewModel
    {
        private bool isProjectUpdate = Settings.Default.IsProjectUpdate;
        private bool isFamilyUpdate = Settings.Default.IsFamilyUpdate;
        private bool isTemplateUpdate = Settings.Default.IsTemplateUpdate;
        private bool isOverwriteFiles;
        private bool isCreateCopies = Settings.Default.IsCreateCopies;
        private bool isDeleteBackup;
        private bool _isIncludeSubfolders = Settings.Default.IsIncludeSubfolders;

        private string _selectedFolder = Settings.Default.LastFolder;

        private RelayCommand _upDate;
        private MainWindow _mainWindow;

        public ViewModel()
        {
            if (Settings.Default.Path1 != "") _folders.Add(Settings.Default.Path1);
            if (Settings.Default.Path2 != "") _folders.Add(Settings.Default.Path2);
            if (Settings.Default.Path3 != "") _folders.Add(Settings.Default.Path3);

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
                Settings.Default.IsProjectUpdate = value;
                OnPropertyChanged();
            }
        }
        public bool IsFamilyUpdate
        {
            get => isFamilyUpdate;
            set
            {
                isFamilyUpdate = value;
                Settings.Default.IsProjectUpdate = value;
                OnPropertyChanged();
            }
        }
        public bool IsTemplateUpdate
        {
            get => isTemplateUpdate;
            set
            {
                isTemplateUpdate = value;
                Settings.Default.IsTemplateUpdate = value;   
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
                Settings.Default.IsCreateCopies = value;
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
            get => _isIncludeSubfolders;
            set
            {
                _isIncludeSubfolders = value;
                Settings.Default.IsIncludeSubfolders = _isIncludeSubfolders;
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

                    UpDateFolderList();
                    OnPropertyChanged("Folders");
                    SaveFolderList();

                    Settings.Default.LastFolder = _selectedFolder;
                }
            }));

        private void UpDateFolderList()
        {
            // add deleting existing folder
            if (!(_folders.Any(f => f == _selectedFolder)))
                {
                    _folders.Add(_selectedFolder);
                    if (_folders.Count > 2) _folders.Remove(_folders[0]);
                }
        }

        private void SaveFolderList()
        {
            if (_folders[0] != "") Settings.Default.Path1 = _folders[0];
            if (_folders[1] != "") Settings.Default.Path2 = _folders[1];
            if (_folders[2] != "") Settings.Default.Path3 = _folders[2];
        }

        public RelayCommand UpDate => _upDate ??
            (_upDate = new RelayCommand(obj =>
            {
                if (_selectedFolder != "")
                {
                    Settings.Default.LastFolder = _selectedFolder;

                    var model = new FamilesExplorer(_selectedFolder, GetExtensions())
                    {
                        IsCopy = IsCreateCopies,
                        GetSubFoldersFiles = IsIncludeSubfolders
                    };

                    FamilyFiles = model.FamilyFiles;

                    Settings.Default.Save();
                    _mainWindow.Close();
                }
            }));

        private ObservableCollection<string> _folders = new ObservableCollection<string>();

        public ObservableCollection<string> Folders
        {
            get { return _folders; }
            set
            {
                //if (value.Count > 1) value.Remove(_folders[0]);
                _folders = value;
                OnPropertyChanged("Folders");
            }
        }

        private string _selectedItem;

        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                _selectedFolder = value;
                OnPropertyChanged("SelectedItem");
            }
        }

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

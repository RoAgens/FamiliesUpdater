
using FamiliesUpdater.Views;
using FamiliesUpdater.Models;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Autodesk.Revit.UI;
using System.Collections.Generic;

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

        //private FamilesExplorer _model;

        public ViewModel()
        {
            //_mainWindow = mainWindow;

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

        private RelayCommand _upDate;
        private string _selectedFolder;
        private MainWindow _mainWindow;

        public List<FamilyFile> FamilyFiles { get; private set; }


        public RelayCommand UpDate => _upDate ??
            (_upDate = new RelayCommand(obj =>
            {
                _selectedFolder = @"E:\__РАБОТА\FamiliesUpdater\FamiliesFolder";

                var model = new FamilesExplorer(_selectedFolder, "rfa");
                FamilyFiles = model.FamilyFiles;
                _mainWindow.Close();
                //model.LoadFamily();
            }));

        //private void ShowReport(int renamedRoomsCount)
        //        => new ReportWindow($"Обновлено {renamedRoomsCount}").Show();
    }
}

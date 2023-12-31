﻿
using FamiliesUpdater.Views;
using FamiliesUpdater.Models;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Autodesk.Revit.UI;

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
            _selectedFolder = @"E:\__РАБОТА\FamiliesUpdater\FamiliesFolder";

            _mainWindow = new MainWindow();
            _mainWindow.DataContext = this;
            _mainWindow.Show();
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

        public RelayCommand UpDate => _upDate ??
            (_upDate = new RelayCommand(obj =>
            {
                var model = new FamilesExplorer(_selectedFolder, "rfa");
                model.LoadFamily();
                _mainWindow.Close();
            }));

        //private void ShowReport(int renamedRoomsCount)
        //        => new ReportWindow($"Обновлено {renamedRoomsCount}").Show();
    }
}

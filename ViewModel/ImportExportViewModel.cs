using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WorkMVVM
{
    public class ImportExportViewModel : BaseViewModel
    {
        #region Properties  
        public ObservableCollection<DepartmentViewModel> Departments { get; set; } = MainViewModel.Instance.Departments;
        public ObservableCollection<EmployeeViewModel> Employees { get; set; } = MainViewModel.Instance.Employees;
        #endregion

        #region Commands
        public RelayCommand ExportCommand { get; set; }
        public RelayCommand ImportCommand { get; set; }
        #endregion

        #region Constructor
        public ImportExportViewModel()
        {
            this.ExportCommand = new RelayCommand(ExportAction, (obj) => true);
            this.ImportCommand = new RelayCommand(ImportAction, (obj) => true);
        }
        #endregion

        #region Command Methods
        private void ExportAction(object obj)
        {
            MainViewModel.Instance.DialogService.SaveFileDialog();
            var filepath = MainViewModel.Instance.DialogService.FilePath;
            MainViewModel.Instance.FileService.Save<DepartmentViewModel>(filepath, this.Departments.ToList());
            MainViewModel.Instance.DialogService.ShowMessage("Отделы выгружены");
        }
        private void ImportAction(object obj)
        {
            MainViewModel.Instance.DialogService.OpenFileDialog();
            var filepath = MainViewModel.Instance.DialogService.FilePath;
            List<DepartmentViewModel> departments = MainViewModel.Instance.FileService.Open<DepartmentViewModel>(filepath);
            ImportBase(departments);
            MainViewModel.Instance.DialogService.ShowMessage("Отделы загружены");
        }
        private void ImportBase(List<DepartmentViewModel> departments)
        {
            AddDepartments(departments);
            AddEmployees(departments);
        }
        private void AddDepartments(List<DepartmentViewModel> departments)
        {
            this.Departments.Clear();
            foreach (var dep in departments)
            {
                this.Departments.Add(dep);
            }
        }
        private void AddEmployees(List<DepartmentViewModel> departments)
        {
            this.Employees.Clear();
            foreach (var department in departments)
            {
                foreach (var emp in department.Employes)
                {
                    this.Employees.Add(emp);
                }
            }
        }
        #endregion
    }
}

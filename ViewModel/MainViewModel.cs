using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WorkMVVM
{
    public class MainViewModel : BaseViewModel
    {
        #region Services 
        public IFileService FileService { get; set; }
        public IDialogService DialogService { get; set; }
        #endregion
        #region Public Properties
        public ObservableCollection<EmployeeViewModel> Employees { get; set; } = new ObservableCollection<EmployeeViewModel>();
        public ObservableCollection<DepartmentViewModel> Departments { get; set; } = new ObservableCollection<DepartmentViewModel>();
        #endregion

        #region Constructor - Singleton
        private static MainViewModel _instance;
        public static MainViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MainViewModel();
                }
                return _instance;
            }
        }
        public MainViewModel()
        {
            this.FileService = new JsonFileService();
            this.DialogService = new DefaultDialogService();

            this.OpenRegisterWindow = new RelayCommand(OpenRegisterWindowAction, (obj) => true);
            this.OpenCurrentEmployeesWindow = new RelayCommand(OpenCurrentEmployeesWindowAction, (obj) => true);
            this.OpenCreateDepartmentWindow = new RelayCommand(OpenCreateDepartmentWindowAction, (obj) => true);
            this.OpenEditDepartmentWindow = new RelayCommand(OpenEditDepartmentWindowAction, (obj) => true);
            this.OpenImportExportWindow = new RelayCommand(OpenImportExportWindowAction, (obj) => true);

            // н-р
            this.Employees.Add(new EmployeeViewModel { FirstName = "Максим", LastName = "Сухарев", Position = "Программист", Salary = 5000, Department = new DepartmentViewModel { Name = "Смарт" } });
            this.Employees.Add(new EmployeeViewModel { FirstName = "Максим", LastName = "Сухарев", Position = "Программист", Salary = 5000, Department = new DepartmentViewModel { Name = "Смарт" } });
            this.Employees.Add(new EmployeeViewModel { FirstName = "Максим", LastName = "Сухарев", Position = "Программист", Salary = 5000, Department = new DepartmentViewModel { Name = "Смарт" } });
            this.Employees.Add(new EmployeeViewModel { FirstName = "Максим", LastName = "Сухарев", Position = "Программист", Salary = 5000, Department = new DepartmentViewModel { Name = "Смарт" } });
            this.Employees.Add(new EmployeeViewModel { FirstName = "Максим", LastName = "Сухарев", Position = "Программист", Salary = 5000, Department = new DepartmentViewModel { Name = "Смарт" } });
            //
            this.Departments.Add(new DepartmentViewModel 
            { 
                Name = "Смарт", 
                Employes = new List<EmployeeViewModel>
                {
                    new EmployeeViewModel
                    {
                        FirstName = "Максим",
                        LastName = "Сухарев",
                        Position = "Программист",
                        Salary = 30000,
                        Department = new DepartmentViewModel
                        {
                            Name = "Смарт",                       
                        }
                    }
                }
            });
            this.Departments.Add(new DepartmentViewModel
            {
                Name = "Веб",
                Employes = new List<EmployeeViewModel>
                {
                    new EmployeeViewModel
                    {
                        FirstName = "Саня",
                        LastName = "Крутой",
                        Position = "Программист",
                        Salary = 15000,
                        Department = new DepartmentViewModel
                        {
                            Name = "Веб",
                        }
                    }
                }
            });
        }
        #endregion

        // Переписать команды тк написаны не читабельно без фоди проперти ченджед
        #region Commands
        public RelayCommand OpenRegisterWindow { get; set; }
        public RelayCommand OpenCurrentEmployeesWindow { get; set; }
        public RelayCommand OpenCreateDepartmentWindow { get; set; }
        public RelayCommand OpenEditDepartmentWindow { get; set; }
        public RelayCommand OpenImportExportWindow { get; set; }
        #endregion

        #region Command Methods
        private void OpenRegisterWindowAction(object obj)
        {
            var regwindow = new RegisterWindow();
            regwindow.Owner = Application.Current.MainWindow;
            regwindow.ShowDialog();
        }

        private void OpenCurrentEmployeesWindowAction(object obj)
        {
            var currentEmployeesWindow = new CurrentEmployeesWindow();
            currentEmployeesWindow.Owner = Application.Current.MainWindow;
            currentEmployeesWindow.ShowDialog();
        }

        private void OpenCreateDepartmentWindowAction(object obj)
        {
            var сreateDepartmentWindow = new CreateDepartmentWindow();
            сreateDepartmentWindow.Owner = Application.Current.MainWindow;
            сreateDepartmentWindow.ShowDialog();
        }

        private void OpenEditDepartmentWindowAction(object obj)
        {
            var editDepartmentWindow = new EditDepartmentWindow();
            editDepartmentWindow.Owner = Application.Current.MainWindow;
            editDepartmentWindow.ShowDialog();
        }

        private void OpenImportExportWindowAction(object obj)
        {
            var importExportWindow = new ImportExportWindow();
            importExportWindow.Owner = Application.Current.MainWindow;
            importExportWindow.ShowDialog();
        }
        #endregion

        #region Private Methods
        private void ImportJsonEmployes()
        {
            // Здесь читать сотрудников
            var employes_json_string = File.ReadAllText("");

            List<EmployeeViewModel> employeeViewModel = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(employes_json_string);
            foreach(var employee in employeeViewModel)
            {
                Employees.Add(employee);
            }
        }

        public void SaveJson(string filename, List<EmployeeViewModel> eployees)
        {
            // filename = path к json
            File.WriteAllText(filename, JsonConvert.SerializeObject(eployees, Formatting.Indented));
        }
        #endregion
    }
}

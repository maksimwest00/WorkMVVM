using System.Collections.ObjectModel;
using System.Security.Principal;
using System.Windows;

namespace WorkMVVM
{
    public class CurrentEmployeesViewModel : BaseViewModel
    {
        #region Public Properties
        public ObservableCollection<EmployeeViewModel> CurrentEmployees { get; set; } = MainViewModel.Instance.Employees;
        private EmployeeViewModel _SelectedEmployee { get; set; }
        public EmployeeViewModel SelectedEmployee
        {
            get { return _SelectedEmployee; }
            set
            {
                _SelectedEmployee = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public RelayCommand OpenSalaryEditWindow { get; set; }
        public RelayCommand OpenDepartmentEditWindow { get; set; }
        #endregion

        #region Constructor
        public CurrentEmployeesViewModel()
        {
            OpenSalaryEditWindow = new RelayCommand(OpenSalaryEditWindowAction, (obj) => true);
            OpenDepartmentEditWindow = new RelayCommand(OpenDepartmentEditWindowAction, (obj) => true);
        }
        #endregion

        #region Command Methods
        private void OpenSalaryEditWindowAction(object obj)
        {
            var salaryEditWindow = new SalaryEditWindow();
            foreach(var window in Application.Current.Windows)
            {
                if(window is CurrentEmployeesWindow)
                {
                    salaryEditWindow.Owner = (Window)window;
                    break;
                }
            }
            salaryEditWindow.ShowDialog();
        }
        private void OpenDepartmentEditWindowAction(object obj)
        {
            var departmentEditWindow = new DepartmentEditWindow();
            foreach (var window in Application.Current.Windows)
            {
                if (window is CurrentEmployeesWindow)
                {
                    departmentEditWindow.Owner = (Window)window;
                    break;
                }
            }
            departmentEditWindow.ShowDialog();
        }
        #endregion
    }
}

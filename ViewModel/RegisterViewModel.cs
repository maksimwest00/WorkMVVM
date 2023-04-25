using System;

namespace WorkMVVM
{
    public class RegisterViewModel : BaseViewModel
    {
        #region Properties    
        private string _firstname = string.Empty;
        public string FirstName
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value;
                OnPropertyChanged();
            }
        }

        private string _lastname = string.Empty;
        public string LastName
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
                OnPropertyChanged();
            }
        }

        private string _postion = string.Empty;
        public string Position
        {
            get
            {
                return _postion;
            }
            set
            {
                _postion = value;
                OnPropertyChanged();
            }
        }

        private int? _salary { get; set; }
        public int? Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                _salary = value;
                OnPropertyChanged();
            }
        }

        private string _department = string.Empty;
        public string DepartmentName
        {
            get
            {
                return _department;
            }
            set
            {
                _department = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public RelayCommand RegisterEmployee { get; set; }
        #endregion

        #region Constructor    
        public RegisterViewModel()
        {
            this.RegisterEmployee = new RelayCommand(RegisterEmployeeAction, (obj) => true);
        }
        #endregion

        #region Command Methods
        private void RegisterEmployeeAction(object parameter)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel.FirstName = this.FirstName;
            employeeViewModel.LastName = this.LastName;
            employeeViewModel.Position = this.Position;
            employeeViewModel.Salary = this.Salary;
            employeeViewModel.Department = new DepartmentViewModel();
            employeeViewModel.Department.Name = this.DepartmentName;

            MainViewModel.Instance.Employees.Add(employeeViewModel);
            MainViewModel.Instance.DialogService.ShowMessage("Регистрация пройдена");
        }
        #endregion
    }
}

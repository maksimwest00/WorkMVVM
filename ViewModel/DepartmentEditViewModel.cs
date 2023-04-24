using System.Collections.ObjectModel;

namespace WorkMVVM
{
    public class DepartmentEditViewModel : BaseViewModel
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
                _newdepartment = _SelectedEmployee.Department.Name;
                OnPropertyChanged("SelectedEmployee");
                OnPropertyChanged("NewSalary");
            }
        }

        private string? _newdepartment { get; set; }
        public string? NewDepartment
        {
            get
            {
                return _newdepartment;
            }
            set
            {
                _newdepartment = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Command
        public RelayCommand UpdateSalary { get; set; }
        public RelayCommand UpdateDepartment { get; set; }
        #endregion

        #region Constructor
        public DepartmentEditViewModel()
        {
            UpdateDepartment = new RelayCommand(UpdateDepartmentAction, (obj) => true);
        }
        #endregion

        #region Command Methods
        private void UpdateDepartmentAction(object obj)
        {
            SelectedEmployee.Department.Name = NewDepartment;
            MainViewModel.Instance.DialogService.ShowMessage("Должность изменена");
        }
        #endregion
    }
}

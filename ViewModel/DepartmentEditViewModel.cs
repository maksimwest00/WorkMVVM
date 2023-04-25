using System.Collections.ObjectModel;

namespace WorkMVVM
{
    public class DepartmentEditViewModel : BaseViewModel
    {
        #region Public Properties
        public ObservableCollection<EmployeeViewModel> CurrentEmployees { get; set; } = MainViewModel.Instance.Employees;
        private EmployeeViewModel? _SelectedEmployee { get; set; }
        public EmployeeViewModel? SelectedEmployee
        {
            get { return _SelectedEmployee; }
            set
            {
                this._SelectedEmployee = value;
                this.NewDepartment = this._SelectedEmployee?.Department?.Name;
                OnPropertyChanged();
            }
        }
        private string? _newdepartment { get; set; }
        public string? NewDepartment
        {
            get
            {
                return this._newdepartment;
            }
            set
            {
                this._newdepartment = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Command
        public RelayCommand UpdateDepartment { get; set; }
        #endregion

        #region Constructor
        public DepartmentEditViewModel()
        {
            this.UpdateDepartment = new RelayCommand(UpdateDepartmentAction, (obj) => true);
        }
        #endregion

        #region Command Methods
        private void UpdateDepartmentAction(object obj)
        {
            if (this.SelectedEmployee is null || this.SelectedEmployee.Department is null) return;
            this.SelectedEmployee.Department.Name = NewDepartment;
            MainViewModel.Instance.DialogService.ShowMessage("Должность изменена");
        }
        #endregion
    }
}

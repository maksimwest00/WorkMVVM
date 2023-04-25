using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WorkMVVM
{
    public class CreateDepartmentViewModel : BaseViewModel
    {
        #region Properties    
        public ObservableCollection<DepartmentViewModel> Departments { get; set; } = MainViewModel.Instance.Departments;

        private string _departmentName = string.Empty;
        public string DepartmentName
        {
            get
            {
                return _departmentName;
            }
            set
            {
                _departmentName = value;
                OnPropertyChanged();
            }
        }
        private List<Cabinet> _cabinets = new List<Cabinet>();
        public List<Cabinet> LastName
        {
            get
            {
                return _cabinets;
            }
            set
            {
                _cabinets = value;
                OnPropertyChanged();
            }
        }
        private List<EmployeeViewModel> _postion = new List<EmployeeViewModel>();
        public List<EmployeeViewModel> Position
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
        #endregion

        #region Commands
        public RelayCommand CreateDepartment { get; set; }
        #endregion

        #region Constructor    
        public CreateDepartmentViewModel()
        {
            CreateDepartment = new RelayCommand(CreateDepartmentAction, (obj) => true);
        }
        #endregion

        #region Command Methods
        private void CreateDepartmentAction(object parameter)
        {
            var newDepartment = new DepartmentViewModel();
            newDepartment.Name = this.DepartmentName;
            this.Departments.Add(newDepartment);
            MainViewModel.Instance.DialogService.ShowMessage("Отдел создан");
        }
        #endregion
    }
}

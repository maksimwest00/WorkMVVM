using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkMVVM
{
    public class EditDepartmentViewModel : BaseViewModel
    {
        #region Properties - Department
        public ObservableCollection<DepartmentViewModel> Departments { get; set; } = MainViewModel.Instance.Departments;
        private DepartmentViewModel _SelectedDepartment { get; set; }
        public DepartmentViewModel SelectedDepartment
        {
            get { return _SelectedDepartment; }
            set
            {
                _SelectedEmployee = null;
                ClearBoxes();
                _SelectedDepartment = value;
                OnPropertyChanged("SelectedEmployee");
                OnPropertyChanged("SelectedDepartment");
                if (_SelectedDepartment is null)
                {
                    return;
                }
                _newDepartmentName = _SelectedDepartment.Name;
                OnPropertyChanged("NewDepartmentName");
            }
        }
        private string _newDepartmentName { get; set; }
        public string? NewDepartmentName
        {
            get
            {
                return _newDepartmentName;
            }
            set
            {
                _newDepartmentName = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Properties - Employee
        private EmployeeViewModel _SelectedEmployee { get; set; }
        public EmployeeViewModel SelectedEmployee
        {
            get { return _SelectedEmployee; }
            set
            {
                _SelectedEmployee = value;
                _newFirstName = _SelectedEmployee.FirstName;
                _newLastName = _SelectedEmployee.LastName;
                _newPosition = _SelectedEmployee.Position;
                _newsalary = _SelectedEmployee.Salary;
                _newDepartment = _SelectedEmployee.Department.Name;
                OnPropertyChanged("NewFirstName");
                OnPropertyChanged("NewLastName");
                OnPropertyChanged("NewPosition");
                OnPropertyChanged("NewSalary");
                OnPropertyChanged("NewDepartment");
                OnPropertyChanged("SelectedEmployee");
            }
        }

        private string _newFirstName { get; set; }
        public string? NewFirstName 
        { 
            get 
            {
                return _newFirstName;
            } 
            set 
            {
                _newFirstName = value;
                OnPropertyChanged();
            } 
        }
        private string _newLastName { get; set; }
        public string? NewLastName
        {
            get
            {
                return _newLastName;
            }
            set
            {
                _newLastName = value;
                OnPropertyChanged();
            }
        }

        private string _newPosition { get; set; }
        public string? NewPosition
        {
            get
            {
                return _newPosition;
            }
            set
            {
                _newPosition = value;
                OnPropertyChanged();
            }
        }

        private int? _newsalary { get; set; }
        public int? NewSalary
        {
            get
            {
                return _newsalary;
            }
            set
            {
                _newsalary = value;
                OnPropertyChanged();
            }
        }

        private string? _newDepartment { get; set; }
        public string? NewDepartment
        {
            get
            {
                return _newDepartment;
            }
            set
            {
                _newDepartment = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public RelayCommand SaveChanges { get; set; }
        #endregion

        #region Constructor
        public EditDepartmentViewModel()
        {
            this.SaveChanges = new RelayCommand(SaveChangesAction, (obj) => true);
        }
        #endregion

        #region Command Methods
        private void SaveChangesAction(object obj)
        {
            this.SelectedDepartment.Name = this.NewDepartmentName;

            this.SelectedEmployee.FirstName = this.NewFirstName;
            this.SelectedEmployee.LastName = this.NewLastName;
            this.SelectedEmployee.Position = this.NewPosition;
            this.SelectedEmployee.Salary = this.NewSalary;
            this.SelectedEmployee.Department.Name = this.NewDepartment;


            if (!(MainViewModel.Instance.Departments.Any(item => item.Name == this.NewDepartment)))
            {
                MainViewModel.Instance.Departments.Add(new DepartmentViewModel
                {
                    Name = this.NewDepartment,
                    Employes = new List<EmployeeViewModel>
                    {
                        new EmployeeViewModel
                        {
                            FirstName = this.NewFirstName,
                            LastName = this.NewLastName,
                            Position = this.NewPosition,
                            Salary = this.NewSalary,
                            Department = new DepartmentViewModel
                            {
                                Name = this.NewDepartment,
                            }
                        }
                    }
                });
            }
            FilterCollection();
            MainViewModel.Instance.DialogService.ShowMessage("Изменения сохранены");
        }

        #endregion

        #region Props Mehods
        private void ClearBoxes()
        {
            this.NewDepartmentName = null;
            this.NewFirstName = null;
            this.NewLastName = null;
            this.NewPosition = null;
            this.NewSalary = null;
            this.NewDepartment = null;
        }
        #endregion

        #region Department Filter
        public void FilterCollection()
        {
            var mutcollection = MainViewModel.Instance.Departments.ToList();
            foreach (DepartmentViewModel department in mutcollection)
            {
                foreach(EmployeeViewModel employee in department.Employes)
                {
                    if(employee.Department.Name != department.Name)
                    {
                        MainViewModel.Instance.Departments.Remove(department);
                    }
                }
            }
        }
        #endregion
    }
}

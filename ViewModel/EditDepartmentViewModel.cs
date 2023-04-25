using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WorkMVVM
{
    public class EditDepartmentViewModel : BaseViewModel
    {
        #region Properties - Department
        public ObservableCollection<DepartmentViewModel> Departments { get; set; } = MainViewModel.Instance.Departments;

        private DepartmentViewModel? _SelectedDepartment { get; set; }
        public DepartmentViewModel? SelectedDepartment
        {
            get { return _SelectedDepartment; }
            set
            {
                SelectedEmployee = null;
                ClearBoxes();
                _SelectedDepartment = value;
                if (_SelectedDepartment != null)
                {
                    NewDepartmentName = _SelectedDepartment.Name;
                    //NewDepartment = _SelectedDepartment;
                }
                OnPropertyChanged();
            }
        }
        private string? _newDepartmentName { get; set; }
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
        private EmployeeViewModel? _SelectedEmployee { get; set; }
        public EmployeeViewModel? SelectedEmployee
        {
            get { return _SelectedEmployee; }
            set
            {
                _SelectedEmployee = value;
                if(_SelectedEmployee != null)
                {
                    NewFirstName = _SelectedEmployee.FirstName;
                    NewLastName = _SelectedEmployee.LastName;
                    NewPosition = _SelectedEmployee.Position;
                    NewSalary = _SelectedEmployee.Salary;
                    if(_SelectedEmployee.Department != null)
                    {
                        DepartmentViewModel selectedEmployee = Departments.First(x => x.Name == _SelectedEmployee.Department.Name);
                        NewDepartment = selectedEmployee;
                    }
                }
                OnPropertyChanged();
            }
        }

        private string? _newFirstName { get; set; }
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
        private string? _newLastName { get; set; }
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

        private string? _newPosition { get; set; }
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

        private DepartmentViewModel? _newDepartment { get; set; }
        public DepartmentViewModel? NewDepartment
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
            UpdateDepartmentName();
            UpdateEmployee();
            UpdateDepartment();
        }

        #endregion

        #region SaveChanges Methods

        private void UpdateDepartmentName()
        {
            if (this.NewDepartmentName != null)
            {
                this.SelectedDepartment.Name = this.NewDepartmentName;
                foreach(var emp in this.SelectedDepartment.Employes)
                {
                    emp.Department.Name = this.NewDepartmentName;
                }
            }
            else
            {
                MainViewModel.Instance.DialogService.ShowMessage("Нету изменений");
            }
        }
        private void UpdateEmployee()
        {
            if(SelectedEmployee != null)
            {
                this.SelectedEmployee.FirstName = this.NewFirstName;
                this.SelectedEmployee.LastName = this.NewLastName;
                this.SelectedEmployee.Position = this.NewPosition;
                this.SelectedEmployee.Salary = this.NewSalary;
            }
        }

        private void UpdateDepartment()
        {
            if(this.SelectedEmployee != null)
            {
                if (this.SelectedEmployee.Department != this.NewDepartment)
                {
                    foreach (var dep in this.Departments)
                    {
                        if (dep.Name != this.NewDepartment.Name)
                        {
                            dep.Employes.Remove(this.SelectedEmployee);
                        }
                        if (dep.Name == NewDepartment.Name)
                        {
                            var employeesDep = dep.Employes.FirstOrDefault(emp => emp.FirstName == this.SelectedEmployee.FirstName);
                            if(employeesDep == null)
                            {
                                dep.Employes.Add(this.SelectedEmployee);
                            }
                        }
                    }
                    this.SelectedEmployee.Department = this.NewDepartment;
                }
            }
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
                var mutcoll = new List<EmployeeViewModel>(department.Employes);
                foreach(EmployeeViewModel employee in mutcoll)
                {
                    if(employee.Department.Name != department.Name)
                    {
                        department.Employes.Remove(employee);
                    }
                    else
                    {
                        var a = department.Employes.Contains(employee);
                        department.Employes.Add(employee);
                        if (!department.Employes.Contains(employee))
                        {
                        }
                    }
                }
            }
        }
        #endregion
    }
}

﻿using System.Collections.ObjectModel;

namespace WorkMVVM
{
    public class SalaryEditViewModel : BaseViewModel
    {
        #region Public Properties
        public ObservableCollection<EmployeeViewModel> CurrentEmployees { get; set; } = MainViewModel.Instance.Employees;
        private EmployeeViewModel? _SelectedEmployee { get; set; }
        public EmployeeViewModel? SelectedEmployee
        {
            get { return _SelectedEmployee; }
            set
            {
                _SelectedEmployee = value;
                NewSalary = _SelectedEmployee?.Salary;
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
        #endregion

        #region Command
        public RelayCommand UpdateSalary { get; set; }
        #endregion

        #region Constructor
        public SalaryEditViewModel()
        {
            this.UpdateSalary = new RelayCommand(UpdateSalaryAction, (obj) => true);
        }
        #endregion

        #region Command Methods
        private void UpdateSalaryAction(object obj)
        {
            if (this.SelectedEmployee is null) return;
            this.SelectedEmployee.Salary = this.NewSalary;
            MainViewModel.Instance.DialogService.ShowMessage("Зарплата изменена");
        }
        #endregion
    }
}

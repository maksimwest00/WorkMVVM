using System.Collections.Generic;

namespace WorkMVVM
{
    public class DepartmentViewModel : BaseViewModel
    {
        private string? _name { get; set; }
        public string? Name 
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public List<Cabinet>? Cabinets { get; set;}
        public List<EmployeeViewModel>? Employes { get; set; }
    }
}

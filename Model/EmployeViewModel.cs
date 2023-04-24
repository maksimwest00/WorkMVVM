using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkMVVM
{
    public class EmployeeViewModel : BaseViewModel
    {
        private string _firstname { get; set; }
        public string? FirstName 
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
        private string _lastname { get; set; }
        public string? LastName 
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
        private string _position { get; set; }
        public string? Position 
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
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
        public DepartmentViewModel? Department { get; set; }
    }
}

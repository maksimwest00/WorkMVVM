using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkMVVM
{
    public class ImportExportViewModel : BaseViewModel
    {
        #region Props   
        public ObservableCollection<DepartmentViewModel> Departments { get; set; } = MainViewModel.Instance.Departments;
        #endregion

        #region Constructor
        public ImportExportViewModel()
        {

        }
        #endregion
    }
}

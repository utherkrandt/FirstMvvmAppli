using MvvmFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManager.ViewModels
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel
        {
            get
            {
                return Ioc.Get<MainViewModel>();
            }
        }
    }
}

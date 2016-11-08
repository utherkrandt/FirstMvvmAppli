using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManager.Views.DesignTime
{
    public class MainDesignTimeViewModel
    {
        public MainDesignTimeViewModel()
        {
            Students = new ObservableCollection<Student> {
                   new Student {Id = 1, EmailAddress = "collin@jn.com", LastName = "Collin", FirstName = "JN", Age = 54 },
                   new Student {Id = 20, EmailAddress = "geert@neuts.com", LastName = "Neuts", FirstName = "Geert", Age = 32 }
            };
        }

        public ObservableCollection<Student> Students { get; set; }
    }
}

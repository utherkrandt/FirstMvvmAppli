using System;
using System.Collections.ObjectModel;
using System.IO;
using DataAccess;
using Models;
namespace StudentsManager.ViewModels
{
    public class MainViewModel
    {
        private IDataProvider<Student> studentXmlProvider;

        public ObservableCollection<Student> Students { get; private set; }

        public MainViewModel(IDataProvider<Student> provider)
        {
            studentXmlProvider = provider;
            ReloadStudents();
        }

        private void ReloadStudents()
        {
           var students = studentXmlProvider.GetAll();
            Students = new ObservableCollection<Student>(students);
        }
    }
}
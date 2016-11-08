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

        public MainViewModel()
        {
            ReloadStudents();
        }

        private void ReloadStudents()
        {
            studentXmlProvider = new StudentsXmlProvider(Path.Combine(Environment.CurrentDirectory,"StudentsRepo.xml"));
            var students = studentXmlProvider.GetAll();
            Students = new ObservableCollection<Student>(students);
        }
    }
}
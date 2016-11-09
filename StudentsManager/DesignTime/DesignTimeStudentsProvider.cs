using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManager.Views.DesignTime
{
    public class DesignTimeStudentsProvider : IDataProvider<Student>
    {
        private ObservableCollection<Student> Students { get; set; }

        public DesignTimeStudentsProvider()
        {
            Students = new ObservableCollection<Student> {
                   new Student {Id = 1, EmailAddress = "collin@jn.com", LastName = "Collin", FirstName = "JN", Age = 54 },
                   new Student {Id = 20, EmailAddress = "geert@neuts.com", LastName = "Neuts", FirstName = "Geert", Age = 32 }
            };
        }

        public void Add(Student entity)
        {
            Students.Add(entity);
        }

        public void Change(Student newEntity)
        {
            var oldEntity = GetById(newEntity.Id);
            oldEntity.Age = newEntity.Age;
            oldEntity.EmailAddress = newEntity.EmailAddress;
            oldEntity.FirstName = newEntity.FirstName;
            oldEntity.LastName = newEntity.LastName;
        }

        public IEnumerable<Student> GetAll()
        {
            return Students;
        }

        public Student GetById(int id)
        {
            return Students.Single(x => x.Id.Equals(id));
        }

        public void Remove(int id)
        {
            Students.Remove(GetById(id));
        }

        public void SubmitChanges()
        {
          
        }
    }
}

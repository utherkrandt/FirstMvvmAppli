using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DataAccess;
using Models;
using MvvmFramework;
using StudentsManager.ViewModels;

namespace StudentsManager.Views
{
    public class Bootstrapper : BootstrapperBase
    {
        private WindsorContainer _container;

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return new[] { typeof(MainViewModel).Assembly };
        }

        protected override void ConfigureForDesign()
        {
            _container = new WindsorContainer();
            _container.Register(
                Component.For<IDataProvider<Student>>()
                    .ImplementedBy<StudentsXmlProvider>()
                    .DependsOn(Dependency.OnValue<string>("StudentsRepo.xml")));

            RegisterViewModel();
            _container.AddFacility<TypedFactoryFacility>();
        }

        protected override void ConfigureForRuntime()
        {
            _container = new WindsorContainer();
            RegisterViewModel();
            _container.AddFacility<TypedFactoryFacility>();
        }

        private void RegisterViewModel()
        {
            _container.Register(Classes.FromAssembly(typeof(MainViewModel).Assembly)
                .Where(x => x.Name.EndsWith("ViewModel"))
                .Configure(x => x.LifeStyle.Is(Castle.Core.LifestyleType.Transient)));

        }

        protected override object GetInstance(Type service, string key)
        {
            return string.IsNullOrWhiteSpace(key) ? _container.Resolve(service) : _container.Resolve(service, key);
        }
    }
}
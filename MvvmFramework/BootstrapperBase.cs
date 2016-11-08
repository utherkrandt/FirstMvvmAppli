using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace MvvmFramework
{
    public abstract class BootstrapperBase
    {
        protected virtual IEnumerable<Assembly> SelectAssemblies()
        {
            return null;
        }

        private static bool ContainsApplicationClass(Assembly assembly)
        {
            return (assembly.EntryPoint != null &&
                      assembly.GetExportedTypes().Any(x => x.IsSubclassOf(typeof(Application)))); ;
        }

        protected abstract object GetInstance(Type service, string key);

        protected virtual void ConfigureForDesign() { }

        protected virtual void ConfigureForRuntime()
        {
        }


        public void Start()
        {
            AssemblySource.Instance.Assemblies.AddRange(SelectAssemblies());
            if (Execution.IsDesignMode)
            {
                ConfigureForDesign();
            }
            else
            {
                ConfigureForRuntime();
            }

            Ioc.GetInstancesFunc = GetInstance;

        }


    }
}
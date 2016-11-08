using System.Collections.Generic;
using System.Reflection;

namespace MvvmFramework
{
    public class AssemblySource
    {
        private static readonly AssemblySource _instance= new AssemblySource();

        public List<Assembly> Assemblies { get; private set; }

        public static AssemblySource Instance
        {
            get
            {
                return _instance;
            }
        }

        private AssemblySource()
        {
            Assemblies = new List<Assembly>();
        }
    }
}
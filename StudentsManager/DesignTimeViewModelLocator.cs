using MvvmFramework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace StudentsManager.Views
{
    public class DesignTimeViewModelLocator : IValueConverter
    {
        private static readonly DesignTimeViewModelLocator _instance= new DesignTimeViewModelLocator();

        public static DesignTimeViewModelLocator Instance { get { return _instance; } }

        static DesignTimeViewModelLocator()
        {
            if(Execution.IsDesignMode)
            {
                var bootstrap = new Bootstrapper();
                bootstrap.Start();
            }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var allTypes = AssemblySource.Instance.Assemblies;
            var exportedType = new List<Type>();

            allTypes.ForEach(x => exportedType.AddRange(x.ExportedTypes));
            var typeName = exportedType.First(x => x.FullName.Equals(value.ToString()));
          return Ioc.GetInstance(typeName,null);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmFramework
{
    public static class AutoViewModelLocator
    {
        public static readonly DependencyProperty AutoAttachViewModelProperty =
            DependencyProperty.RegisterAttached("AutoAttachViewModel",typeof(bool),typeof(AutoViewModelLocator),new PropertyMetadata(false,AutoViewModelChanged));

        private static void AutoViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(d))
                return;
            var viewType = d.GetType();
            var viewModelTypeName = viewType.FullName.Replace("View", "ViewModel");
            var assemblies = AssemblySource.Instance.Assemblies;
            var allTypes = new List<Type>();
            assemblies.ForEach(x => allTypes.AddRange(x.ExportedTypes));
            var viewModelType = allTypes.Single(x => x.FullName.Equals(viewModelTypeName));
            var viewModelInstance = Ioc.GetInstance(viewModelType, null);
            ((FrameworkElement)d).DataContext = viewModelInstance;
        }

        public static bool GetAutoAttachViewModel(DependencyObject obj)
        {
           return (bool) obj.GetValue(AutoAttachViewModelProperty);
        }

        public static void SetAutoAttachViewModel(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoAttachViewModelProperty, value);
        }
    }
}

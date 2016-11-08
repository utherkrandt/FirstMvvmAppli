using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;

namespace MvvmFramework
{
    public static class Execution
    {
        private const string DevName = "devenv";
        private static bool? _isDesignMode;

        public static bool IsDesignMode
        {
            get
            {
                if (_isDesignMode == null)
                {
                    var prop = DesignerProperties.IsInDesignModeProperty;
                    _isDesignMode =
                        (bool)
                            DependencyPropertyDescriptor.FromProperty(prop, typeof (FrameworkElement))
                                .Metadata.DefaultValue;
                    if (
                        Process.GetCurrentProcess().ProcessName.StartsWith(DevName, StringComparison.OrdinalIgnoreCase) &&
                        !_isDesignMode.GetValueOrDefault(false))
                        _isDesignMode = true;
                }
                return _isDesignMode.GetValueOrDefault(false);
            }
        }
    }
}
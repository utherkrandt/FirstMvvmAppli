using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Policy;

namespace MvvmFramework
{
    public static class Ioc
    {
        public static Func<Type, string, object> GetInstancesFunc = (service, key) => { throw new InvalidOperationException("IOC not initialized."); };

        public static Func<Type, IEnumerable<object>> GetAllInstancesFunc = (service) => { throw new InvalidOperationException("IOC not initialized."); };

        public static Action<object> BuildUpAction = (service) => { throw new InvalidOperationException("IOC not initialized."); };

        public static T Get<T>(string key = null)
        {
            return (T) GetInstancesFunc(typeof (T), key);
        }

        public static object GetInstance(Type service, string key = null)
        {
            return GetInstancesFunc(service, key);
        }

        public static IEnumerable<T> GetAllInstances<T>()
        {
            return GetAllInstancesFunc(typeof (T)).Cast<T>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.Common.Helpers;

[Description("Helper class for using Reflection namespace")]
public static class ReflectionHelper
{
    /// <summary>
    /// Create instances of all subclasses of given generic type with provided constructor parameters
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="args">Parameters for specific construnctor</param>
    /// <returns></returns>
    public static IEnumerable<T?> InstantiateAllSubclasses<T>(object[] args) where T : class
    {
        return typeof(T).Assembly.GetTypes()
                   .Where(x => x.IsSubclassOf(typeof(T)) && !x.IsAbstract)
                   .Select(y => (T?)Activator.CreateInstance(y, args)).ToList();
    }

    /// <summary>
    /// Get all interfaces that are implemented by provided generic type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerable<T> GetAllImplementingInterfaces<T>()
    {
        return (IEnumerable<T>)typeof(T).Assembly.GetTypes()
            .Where((x) => x.IsAssignableFrom(typeof(T)));
    }

    /// <summary>
    /// Get all subclasses of provided generic type and assembly
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static List<TypeInfo> GetAllSubclasses<T>(Assembly assembly)
    {
        return assembly.DefinedTypes.Where(x => x.BaseType?.Name == typeof(T).Name).ToList();
    } 
}

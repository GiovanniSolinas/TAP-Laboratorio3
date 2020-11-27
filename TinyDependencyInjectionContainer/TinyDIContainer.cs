using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TinyDependencyInjectionContainer
{
    public class InterfaceResolver
    {
        private Dictionary<Type, Type> KnownTypes { get; }

        public InterfaceResolver(string configFileName)
        {

            var lines = File.ReadAllLines(configFileName);
            KnownTypes = new Dictionary<Type, Type>();
            foreach (var line in lines)
            {
                if(0 == line.Length || '#' == line[0])
                    continue;
                var parts = line.Split('*');
                if (4 != parts.Length)
                    throw new ArgumentException(
                        $"Invalid config file: line with {parts.Length} parts instead of the required 4");
                try
                {
                    var interfaceDll = Assembly.LoadFrom(parts[0]);
                    var interfaceType = interfaceDll.GetType(parts[1]);
                    var implementationDll = Assembly.LoadFrom(parts[2]);
                    var implementationType = implementationDll.GetType(parts[3]);
                    if (interfaceType.IsAssignableFrom(implementationType))
                        KnownTypes[interfaceType] = implementationType;
                    else
                        throw new ArgumentException($"Type {implementationType.FullName} does not implement {interfaceType.FullName}");

                }
                catch (Exception e)
                {
                    Console.WriteLine($"Config file {configFileName} contains errors!");
                    Console.WriteLine(e);
                }
            }
        }

        public T Instantiate<T>() where T : class
        {
            return (T)Activator.CreateInstance(KnownTypes[typeof(T)]);
        }
    }
}

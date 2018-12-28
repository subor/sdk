using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ruyi.Layer0
{
    /// <summary>
    /// Caches generated types
    /// </summary>
    public sealed class GeneratedTypeCache
    {
        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <param name="name">Fully-qualified name like "Ruyi.SDK.InputManager.InputDeviceStateChanged"</param>
        /// <returns></returns>
        public static Type GetType(string name)
        {
            lock (sync)
            {
                if (cachedTypes.TryGetValue(name, out var ret))
                    return ret;

                Type tp = null;
                foreach (var assem in assemblies)
                {
                    tp = assem.GetType(name);
                    if (tp != null)
                    {
                        cachedTypes.Add(name, tp);
                        break;
                    }
                }
                return tp;
            }
        }

        /// <summary>
        /// get type by not fully qualified class name, or qualified with full namespace
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        public static Type GetTypeByClassName(string className)
        {
            lock (sync)
            {
                if (cachedClassnames.TryGetValue(className, out var ret))
                    return ret;

                foreach (var assem in assemblies)
                {
                    Type[] types = assem.GetTypes();
                    foreach (var type in types)
                    {
                        if (type.Name.Equals(className, StringComparison.OrdinalIgnoreCase)
                            || type.FullName.Equals(className, StringComparison.OrdinalIgnoreCase))
                        {
                            cachedClassnames.Add(className, type);
                            return type;
                        }
                    }
                }
                return null;
            }
        }

        static GeneratedTypeCache()
        {
            lock (sync)
            {
#if NASYNC
                tryLoadAssembly("ServiceGenerated");
                tryLoadAssembly("ServiceCommon");
                tryLoadAssembly("InternalServiceGenerated");
#else
                tryLoadAssembly("SDK.Gen.ServiceAsync");
                tryLoadAssembly("SDK.Gen.CommonAsync");
                tryLoadAssembly("SDK.Gen.InternalServiceAsync");
#endif

                tryLoadAssembly("TypeLibAsync");
            }
        }

        static void tryLoadAssembly(string name)
        {
            try
            {
                assemblies.Add(Assembly.Load(name));
            }
            catch
            { }
        }

        static object sync = new object();
        static Dictionary<string, Type> cachedTypes = new Dictionary<string, Type>();
        static Dictionary<string, Type> cachedClassnames = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
        static List<Assembly> assemblies = new List<Assembly>();
    }
}

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

        static GeneratedTypeCache()
        {
            lock (sync)
            {
#if NASYNC
                assemblies = new[]
                    {
                        Assembly.Load("ServiceGenerated"),
                        Assembly.Load("ServiceCommon"),
                        Assembly.Load("InternalServiceGenerated"),
                    };
#else
                assemblies = new[]
                    {
                        Assembly.Load("SDK.Gen.ServiceAsync"),
                        Assembly.Load("SDK.Gen.CommonAsync"),
                        Assembly.Load("SDK.Gen.InternalServiceAsync"),
                    };
#endif
            }
        }

        static object sync = new object();
        static Dictionary<string, Type> cachedTypes = new Dictionary<string, Type>();
        static Assembly[] assemblies;
    }
}

using NetMQ;
using NetMQ.Sockets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using Thrift.Protocol;
using Thrift.Transport;

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

                var assem = Assembly.Load("ServiceGenerated");
                var tp = assem.GetType(name);
                if (tp == null)
                {
                    assem = Assembly.Load("ServiceCommon");
                    tp = assem?.GetType(name);
                }
                if (tp == null)
                {
                    assem = Assembly.Load("InternalServiceGenerated");
                    tp = assem?.GetType(name);
                }
                if (tp != null)
                {
                    cachedTypes.Add(name, tp);
                }
                return tp;
            }
        }

        static object sync = new object();
        static Dictionary<string, Type> cachedTypes = new Dictionary<string, Type>();
    }
}

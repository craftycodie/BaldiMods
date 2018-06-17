using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BaldiMods.Components
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    class ModComponentAttribute : Attribute
    {
        static ModComponentAttribute()
        {
            var modComponents =     (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                                    from assemblyType in domainAssembly.GetExportedTypes()
                                    where assemblyType.GetCustomAttributes(typeof(ModComponentAttribute), false).Length > 0
                                    select assemblyType).ToArray();

            foreach(Type modComponent in modComponents)
            {
                if (!modComponent.IsSubclassOf(typeof(MonoBehaviour)))
                    continue;
                    //Log warning.
            }
        }

        public readonly ModComponentType componentType;
        public readonly bool disabled;

        public ModComponentAttribute(ModComponentType componentType, bool disabled)
        {
            this.componentType = componentType;
            this.disabled = disabled;
        }
    }
}

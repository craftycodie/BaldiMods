using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BaldiMods.Overrides
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    class OverrideComponentAttribute : Attribute
    {
        static OverrideComponentAttribute()
        {
            var overrideComponents = (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                                     from assemblyType in domainAssembly.GetExportedTypes()
                                     where assemblyType.GetCustomAttributes(typeof(OverrideComponentAttribute), false).Length > 0
                                     select assemblyType).ToArray();

            foreach (Type overrideComponent in overrideComponents)
            {
                if (!overrideComponent.IsSubclassOf(typeof(MonoBehaviour)))
                    continue;
                //Log warning.
            }
        }

        public void Update()
        {
            if (disabled)
                return;

            foreach (MonoBehaviour component in UnityEngine.Object.FindObjectsOfType(overriddenType))
            {
                component.enabled = false;
                component.gameObject.AddComponent(overridingType);
            }
        }

        public readonly Type overridingType;
        public readonly Type overriddenType;
        public readonly bool disabled;

        public OverrideComponentAttribute(Type overridingType, Type overriddenType)
        {
            if (!overriddenType.IsSubclassOf(typeof(MonoBehaviour)))
                //Log Error
                disabled = true;

            if (!overridingType.IsSubclassOf(typeof(MonoBehaviour)))
                //Log Error
                disabled = true;

            this.overridingType = overridingType;
            this.overriddenType = overriddenType;

            ModController.update = Update;
        }
    }
}

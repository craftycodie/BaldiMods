using BaldiMods.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace BaldiMods
{
    public class ComponentFactory : MonoBehaviour
    {
        public static ComponentFactory singleton;
        protected static List<Type> registeredComponents;

        static ComponentFactory()
        {
            //Initialize the components list.
            //From all of the assemblies in the current domain,
            //from all of the exported (public) types in the assembly,
            //get types that:
            //  - Derive from MonoBehaviour
            //  - Aren't Abstract
            //  - Have the ModComponentAttribute
            registeredComponents = (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                                    from assemblyType in domainAssembly.GetExportedTypes()
                                    where assemblyType.IsSubclassOf(typeof(MonoBehaviour))
                                    && !assemblyType.IsAbstract 
                                    && assemblyType.GetCustomAttributes(typeof(ModComponentAttribute), false).Length > 0
                                    select assemblyType).ToList();
        }

        public static void CreateFactoryComponent()
        {
            if (singleton) return;
            //Should log this.

            GameObject go = new GameObject();
            singleton = go.AddComponent<ComponentFactory>();
            DontDestroyOnLoad(singleton);
        }

        public void Start()
        {
            SceneManager.activeSceneChanged += ActiveSceneChanged;
            CreateComponents();
            CreateSceneComponents();
        }

        public void ActiveSceneChanged(Scene oldScene, Scene newScene)
        {
            CreateSceneComponents();
        }

        public void CreateComponents()
        {
            foreach(Type t in registeredComponents)
            {
                ModComponentAttribute attribute = t.GetCustomAttributes(typeof(ModComponentAttribute), false)[0] as ModComponentAttribute;

                if (attribute.disabled)
                    continue;

                if (!attribute.componentType.HasFlag(ModComponentType.DontDestroyOnLoad))
                    continue;

                gameObject.AddComponent(t);
            }
        }

        /// <summary>
        /// Called every time the active scene changes.
        /// </summary>
        public void CreateSceneComponents()
        {
            GameObject sceneObject = new GameObject();

            foreach (Type t in registeredComponents)
            {
                ModComponentAttribute attribute = t.GetCustomAttributes(typeof(ModComponentAttribute), false)[0] as ModComponentAttribute;

                if (attribute.disabled)
                    continue;

                if (!attribute.componentType.HasFlag(ModComponentType.RecreateOnSceneChange))
                    continue;

                sceneObject.AddComponent(t);
            }
        }

        public void Update()
        {
            ModController.update();
        }

        public void LateUpdate()
        {
            ModController.lateUpdate();
        }

        public void FixedUpdate()
        {
            ModController.fixedUpdate();
        }
    }
}

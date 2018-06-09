using BaldiMods.Components;
using System;
using System.Collections.Generic;
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

        public static void CreateFactory()
        {
            if (singleton) return;

            GameObject go = new GameObject();
            singleton = go.AddComponent<ComponentFactory>();
            DontDestroyOnLoad(singleton);
        }

        public void Start()
        {
            SceneManager.activeSceneChanged += ActiveSceneChanged;
            CreateComponents();
        }

        public void ActiveSceneChanged(Scene oldScene, Scene newScene)
        {
            CreateSceneComponents();
        }

        public void CreateComponents()
        {
            gameObject.AddComponent<GUIComponent>();
            gameObject.AddComponent<PlayerControllerOverrideComponent>();
        }

        public void CreateSceneComponents()
        {
            GameObject sceneObject = new GameObject();
            sceneObject.AddComponent<GodModeComponent>();
            sceneObject.AddComponent<PlayerControllerOverrideComponent>();
            sceneObject.AddComponent<BaldiAngerControllerComponent>();
            //sceneObject.AddComponent<PlaytimeDupeComponent>();
            sceneObject.AddComponent<AssetLoaderComponent>();
        }
    }
}

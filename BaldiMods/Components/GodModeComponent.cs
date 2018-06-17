using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BaldiMods.Components
{
    [ModComponent(ModComponentType.RecreateOnSceneChange, false)]
    public class GodModeComponent : MonoBehaviour
    {
        GameControllerScript gc;
        void Start()
        {
            gc = FindObjectOfType<GameControllerScript>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))
                gc.debugMode = !gc.debugMode;
        }
    }
}

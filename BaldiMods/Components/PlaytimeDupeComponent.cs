using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BaldiMods.Components
{
    [ModComponent(ModComponentType.RecreateOnSceneChange, true)]
    class PlaytimeDupeComponent : MonoBehaviour
    {
        void Start()
        {
            GameControllerScript gc = FindObjectOfType<GameControllerScript>();
            GameObject pt = gc.playtime;
            pt.SetActive(true);
            for (int i = 0; i < 100; i++)
            {
                Instantiate(pt);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BaldiMods.Components
{
    class GUIComponent : MonoBehaviour
    {
        public void OnGUI()
        {
            GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "BaldiMods");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BaldiMods.Components
{
    class GottaSweepDupeComponent : MonoBehaviour
    {
        void Start()
        {
            GameControllerScript gc = FindObjectOfType<GameControllerScript>();
            GameObject pt = gc.gottaSweep;
            pt.SetActive(true);
            for (int i = 0; i < 100; i++)
            {
                Instantiate(pt);
            }
        }
    }
}

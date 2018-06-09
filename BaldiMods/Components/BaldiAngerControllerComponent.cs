using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BaldiMods.Components
{
    class BaldiAngerControllerComponent : MonoBehaviour
    {
        void Update()
        {
            BaldiScript bs = FindObjectOfType<BaldiScript>();
            if (Input.GetKeyDown(KeyCode.O))
                bs.GetAngry(1f);
            if (Input.GetKeyDown(KeyCode.I))
                bs.GetAngry(-1f);
            if (Input.GetKeyDown(KeyCode.L))
                Instantiate(bs.gameObject);
        }
    }
}

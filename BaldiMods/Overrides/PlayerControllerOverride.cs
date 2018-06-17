using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BaldiMods.Overrides
{
    [OverrideComponent(typeof(PlayerControllerOverride), typeof(PlayerScript))]
    public class PlayerControllerOverride : MonoBehaviour
    {
        bool enableOverride = false;

        Rigidbody rb;
        PlayerScript ps;

        public PlayerControllerOverride()
        {
            rb = GetComponent<Rigidbody>();
            ps = GetComponent<PlayerScript>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.V))
                ToggleOverride();
        }

        void ToggleOverride()
        {
            enableOverride = !enableOverride;

            rb.detectCollisions = !enableOverride;
            rb.isKinematic = !enableOverride;
        }
    }
}

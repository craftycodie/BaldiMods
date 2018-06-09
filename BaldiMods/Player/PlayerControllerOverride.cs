using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BaldiMods.Player
{
    public class PlayerControllerOverride : MonoBehaviour
    {
        static void ActiveSceneChanged(Scene current, Scene next)
        {
            //Check for player.
            PlayerScript ps = UnityEngine.Object.FindObjectOfType<PlayerScript>();
            if (!ps) return;

            ps.gameObject.AddComponent<PlayerControllerOverride>();
        }

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

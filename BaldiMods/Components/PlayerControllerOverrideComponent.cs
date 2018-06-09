using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BaldiMods.Components
{
    public class PlayerControllerOverrideComponent : MonoBehaviour
    {
        bool enableOverride = false;
        int moveSpeed = 1;

        Rigidbody rb;
        PlayerScript ps;
        CameraScript cs;

        public void Start()
        {
            ps = FindObjectOfType<PlayerScript>();
            rb = ps.gameObject.GetComponent<Rigidbody>();
            cs = FindObjectOfType<CameraScript>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.V))
                ToggleOverride();

            if(enableOverride)
            {
                if (Input.GetKey(KeyCode.W))
                    ps.transform.position += cs.transform.forward * moveSpeed;
                if (Input.GetKey(KeyCode.S))
                    ps.transform.position -= cs.transform.forward * moveSpeed;
                if (Input.GetKey(KeyCode.D))
                    ps.transform.position += cs.transform.right * moveSpeed;
                if (Input.GetKey(KeyCode.A))
                    ps.transform.position -= cs.transform.right * moveSpeed;
                if (Input.GetKey(KeyCode.Space))
                    ps.transform.position += cs.transform.up * moveSpeed;
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    ps.transform.position -= cs.transform.up * moveSpeed;
                }
            }
        }
        
        void LateUpdate()
        {
            if(enableOverride)
                cs.transform.rotation = ps.transform.rotation;
        }

        void ToggleOverride()
        {
            enableOverride = !enableOverride;

            rb.detectCollisions = !enableOverride;
            rb.isKinematic = !enableOverride;
        }
    }
}

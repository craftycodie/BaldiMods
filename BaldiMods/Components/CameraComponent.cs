using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BaldiMods.Components
{
    [ModComponent(ModComponentType.RecreateOnSceneChange, true)]
    class CameraComponent : MonoBehaviour
    {
        public float initVelocity;

        public float velocity;

        public float gravity;

        private int lookBehind;

        private Vector3 offset;

        public float jumpHeight;

        private Vector3 jumpHeightV3;

        GameObject camera;
        PlayerScript ps;
        BaldiScript bs;

        private void Start()
        {
            camera = FindObjectOfType<CameraScript>().gameObject;
            ps = FindObjectOfType<PlayerScript>();
            Destroy(camera.GetComponent<CameraScript>());
            this.offset = camera.transform.position - ps.transform.position;
        }

        private void Update()
        {
            if (this.ps.jumpRope)
            {
                this.velocity -= this.gravity * Time.deltaTime;
                this.jumpHeight += this.velocity * Time.deltaTime;
                if (this.jumpHeight <= 0f)
                {
                    this.jumpHeight = 0f;
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        this.velocity = this.initVelocity;
                    }
                }
                this.jumpHeightV3 = new Vector3(0f, this.jumpHeight, 0f);
            }
            else if (Input.GetButton("Look Behind"))
            {
                this.lookBehind = 180;
            }
            else
            {
                this.lookBehind = 0;
            }
        }

        private void LateUpdate()
        {
            base.transform.position = ps.transform.position + this.offset;
            if (!this.ps.gameOver & !this.ps.jumpRope)
            {
                camera.transform.position = ps.transform.position + this.offset;
                camera.transform.rotation = Quaternion.Euler(new Vector3((ps.transform.rotation * Quaternion.Euler(0f, (float)this.lookBehind, 0f)).x, camera.transform.rotation.y, camera.transform.rotation.z));
                camera.transform.eulerAngles = camera.transform.eulerAngles + new Vector3(Input.GetAxis("Mouse Y") * PlayerPrefs.GetFloat("MouseSensitivity"), 0f, 0f);
            }
            else if (this.ps.gameOver)
            {
                camera.transform.position = bs.transform.position + bs.transform.forward * 2f + new Vector3(0f, 5f, 0f);
                camera.transform.LookAt(new Vector3(bs.transform.position.x, bs.transform.position.y + 5f, bs.transform.position.z));
            }
            else if (this.ps.jumpRope)
            {
                camera.transform.position = ps.transform.position + this.offset + this.jumpHeightV3;
                camera.transform.rotation = Quaternion.Euler(new Vector3((ps.transform.rotation * Quaternion.Euler(0f, (float)this.lookBehind, 0f)).x, camera.transform.rotation.y, camera.transform.rotation.z));
            }
        }
    }
}

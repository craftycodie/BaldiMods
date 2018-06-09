using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BaldiMods.Components
{
    class AssetLoaderComponent : MonoBehaviour
    {
        public void Start()
        {
            AssetBundle assetBundle = AssetBundle.LoadFromFile(Directory.GetParent(Application.dataPath).FullName + "\\sandtrap");
            bool flag = assetBundle == null;
            if (flag)
            {
                Debug.Log("Failed to load AssetBundle!");
            }
            else
            {
                GameObject original = assetBundle.LoadAsset<GameObject>("shrine");
                GameObject gameObject = Instantiate(original);
                assetBundle.Unload(false);
                GameObject gameObject2 = GameObject.Find("Meshes");
                bool flag2 = gameObject2;
                if (flag2)
                {
                    Destroy(gameObject2);
                }
                gameObject.transform.Rotate(new Vector3(-90f, 0f, 0f));
                gameObject.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
                GameObject gameObject3 = GameObject.CreatePrimitive(PrimitiveType.Plane);
                gameObject3.SetActive(false);
                Material sharedMaterial = gameObject3.GetComponent<MeshRenderer>().sharedMaterial;
                DestroyImmediate(gameObject3);
                foreach (Transform transform in gameObject.transform)
                {
                    transform.gameObject.AddComponent<MeshCollider>();
                    transform.gameObject.GetComponent<Renderer>().material = sharedMaterial;
                }
            }
        }
    }
}

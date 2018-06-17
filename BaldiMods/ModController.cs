using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace BaldiMods
{
    public static class ModController
    {
        public static UnityAction update;
        public static UnityAction lateUpdate;
        public static UnityAction fixedUpdate;

        private static bool gameInitialized = false;
        private static void GameInitialized()
        {
            ComponentFactory.CreateFactoryComponent();
        }

        public static void MainMenuStart()
        {
            if (!gameInitialized)
            {
                gameInitialized = true;
                GameInitialized();
            }

        }

        public static void StartGamePressed()
        {
        }
    }
}

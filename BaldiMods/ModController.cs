using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace BaldiMods
{
    public static class ModController
    {
        private static bool gameInitialized = false;
        private static void GameInitialized()
        {
            ComponentFactory.CreateFactory();
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

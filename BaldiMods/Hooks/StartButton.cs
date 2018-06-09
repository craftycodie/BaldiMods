using System;
using System.Collections.Generic;
using System.Text;

namespace BaldiMods.Hooks
{
    class StartButton
    {
        public static void Start()
        {
            ModController.MainMenuStart();
        }
    }
}

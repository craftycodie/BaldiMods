using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaldiMods.Components
{
    [Flags]
    public enum ModComponentType
    {
        DontDestroyOnLoad,
        RecreateOnSceneChange
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;//to access menu item

namespace MyTools
{
    public class MassRenamer_Menu
    {
        [MenuItem("MyTools/Level Tools/Rename Objects %#r")] //%-ctrl, #-shift, r-keyboard hotkey
        public static void RenameSelectedObjects()
        {
            MassRenamer_Editor.LaunchRenamer();
        }
    }
}


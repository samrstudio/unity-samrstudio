using UnityEditor;

namespace SamrStudio.Core.Editor
{
    public class CodeTemplatesMenuItems
    {
        private const string MENU_ITEM_PATH = "Assets/Create/";
        private const int MENU_ITEM_PRIORITY = 70;

        [MenuItem(MENU_ITEM_PATH + "BasicScripts/C# Interface", false, MENU_ITEM_PRIORITY)]
        private static void CreateBasicInterface()
        {
            CodeTemplates.CreateFromTemplate (
                "BasicInterface.cs",
                @"Packages/com.samrstudio.core/Editor/CodeTemplates/Templates/BasicInterface.txt"
            );
        }

        [MenuItem(MENU_ITEM_PATH + "BasicScripts/C# Script", false, MENU_ITEM_PRIORITY)]
        private static void CreateBasicScript()
        {
            CodeTemplates.CreateFromTemplate (
                "BasicScript.cs",
                @"Packages/com.samrstudio.core/Editor/CodeTemplates/Templates/BasicScript.txt"
            );
        }

        [MenuItem(MENU_ITEM_PATH + "BasicScripts/C# ScriptableObject", false, MENU_ITEM_PRIORITY)]
        private static void CreateBasicScriptableObject()
        {
            CodeTemplates.CreateFromTemplate (
                "BasicScriptableObject.cs",
                @"Packages/com.samrstudio.core/Editor/CodeTemplates/Templates/BasicScriptableObject.txt"
            );
        }
    }
}
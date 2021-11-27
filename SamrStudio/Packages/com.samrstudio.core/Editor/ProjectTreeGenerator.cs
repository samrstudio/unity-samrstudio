using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;

namespace SamrStudio.Core.Editor
{
    class Folder
    {
        public string DirPath { get; private set; }
        public string ParentPath { get; private set; }
        public string Name;
        public List<Folder> SubFolders;

        public Folder Add(string name)
        {
            Folder subFolder = null;
            if (ParentPath.Length > 0)
                subFolder = new Folder(name, ParentPath + Path.DirectorySeparatorChar + Name);
            else
                subFolder = new Folder(name, Name);

            SubFolders.Add(subFolder);

            return subFolder;
        }

        public Folder(string name, string dirPath)
        {
            Name = name;
            ParentPath = dirPath;
            DirPath = ParentPath + Path.DirectorySeparatorChar + Name;
            SubFolders = new List<Folder>();
        }
    }

    public class CreateProjectTree
    {
        [MenuItem("Tools/Project/Generate Project Tree")]
        public static void Execute()
        {
            var assets = GenerateFolderStructure();
            CreateFolders(assets);
        }

        private static void CreateFolders(Folder rootFolder)
        {
            if (!AssetDatabase.IsValidFolder(rootFolder.DirPath))
            {
                Debug.Log("Creating: <b>" + rootFolder.DirPath + "</b>");
                AssetDatabase.CreateFolder(rootFolder.ParentPath, rootFolder.Name);
            }

            foreach (var folder in rootFolder.SubFolders)
            {
                CreateFolders(folder);
            }
        }

        private static Folder GenerateFolderStructure()
        {
            Folder rootFolder = new Folder("Assets", "");

            rootFolder.Add("Plugins");
            rootFolder.Add("3rdParty");

            Folder GameAssets = rootFolder.Add("__GAME_ASSETS");
            GameAssets.Add("__Shared");
            GameAssets.Add("Events");

            Folder Player = GameAssets.Add("Player");
            Player.Add("Input");
            Player.Add("Prefabs");
            Player.Add("Scripts");

            Folder Scenes = GameAssets.Add("Scenes");

            Folder Management = Scenes.Add("Management");
            Management.Add("ScriptableObjects");

            Folder Menus = Scenes.Add("Menus");
            Menus.Add("ScriptableObjects");

            Folder Levels = Scenes.Add("Levels");
            Levels.Add("ScriptableObjects");

            Folder Systems = GameAssets.Add("Systems");
            Systems.Add("Scripts");

            GameAssets.Add("UI");

            return rootFolder;
        }
    }
}
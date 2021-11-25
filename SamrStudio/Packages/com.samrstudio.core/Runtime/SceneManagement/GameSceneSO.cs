using UnityEngine.AddressableAssets;
using UnityEngine;
using SamrStudio.Core.Utilities;

namespace SamrStudio.Core.SceneManagement
{
    /// <summary>
    /// This class is a base class which contains what is common to all game scenes (Locations, Menus, Managers)
    /// </summary>
    [CreateAssetMenu(fileName = "New Scene", menuName = "SamrStudio/Scene Data/Game Scene")]
    public class GameSceneSO : DescriptionBaseSO
    {
        public string Id;
        public string Name;
        public GameSceneType SceneType;
        public AssetReference SceneReference; //Used at runtime to load the scene from the right AssetBundle
        //public AudioCueSO musicTrack;
        public Sprite UIImage;

        /// <summary>
        /// Used by the SceneSelector tool to discern what type of scene it needs to load
        /// </summary>
        public enum GameSceneType
        {
            //Playable scenes
            Location, //SceneSelector tool will also load PersistentManagers and Gameplay
            Menu, //SceneSelector tool will also load Gameplay

            //Special scenes
            Initialisation,
            PersistentManagers,
            Gameplay,

            //Work in progress scenes that don't need to be played
            Art,
        }
    }
}

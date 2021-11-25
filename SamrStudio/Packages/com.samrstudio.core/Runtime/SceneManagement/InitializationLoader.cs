using SamrStudio.Core.Events;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace SamrStudio.Core.SceneManagement
{
    public class InitializationLoader : MonoBehaviour
    {
        [SerializeField] private GameSceneSO _managersScene = default;
        [SerializeField] private GameSceneSO _menuToLoad = default;

        [Header("Broadcasting on")]
        [SerializeField] private AssetReference _menuLoadEvent = default;

        private void Start()
        {
            //Load the persistent managers scene
            _managersScene.SceneReference.LoadSceneAsync(LoadSceneMode.Additive, true).Completed += LoadEventChannel;
        }

        private void LoadEventChannel(AsyncOperationHandle<SceneInstance> obj)
        {
            _menuLoadEvent.LoadAssetAsync<LoadEventSO>().Completed += LoadMainMenu;
        }

        private void LoadMainMenu(AsyncOperationHandle<LoadEventSO> obj)
        {
            obj.Result.RaiseEvent(_menuToLoad, true);

            SceneManager.UnloadSceneAsync(0); //Initialization is the only scene in BuildSettings, thus it has index 0
        }
    }
}

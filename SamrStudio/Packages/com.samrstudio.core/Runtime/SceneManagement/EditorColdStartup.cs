using SamrStudio.Core.Events;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace SamrStudio.Core.SceneManagement
{
    /// <summary>
    /// Allows a "cold start" in the editor, when pressing Play and not passing from the Initialisation scene.
    /// </summary> 
    public class EditorColdStartup : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField] private GameSceneSO _thisSceneSO = default;
        [SerializeField] private GameSceneSO _persistentManagersSO = default;
        [SerializeField] private AssetReference _notifyColdStartupEvent = default;
        [SerializeField] private VoidEventSO _onSceneReadyEvent = default;

        private bool isColdStart = false;
        private void Awake()
        {
            if (!SceneManager.GetSceneByName(_persistentManagersSO.SceneReference.editorAsset.name).isLoaded)
            {
                isColdStart = true;
            }
        }

        private void Start()
        {
            if (isColdStart)
            {
                _persistentManagersSO.SceneReference.LoadSceneAsync(LoadSceneMode.Additive, true).Completed += LoadEventChannel;

            }
        }

        private void LoadEventChannel(AsyncOperationHandle<SceneInstance> obj)
        {
            _notifyColdStartupEvent.LoadAssetAsync<LoadEventSO>().Completed += OnNotifyChannelLoaded;
        }

        private void OnNotifyChannelLoaded(AsyncOperationHandle<LoadEventSO> obj)
        {
            if (_thisSceneSO != null)
            {
                obj.Result.RaiseEvent(_thisSceneSO);
            }
            else
            {
                _onSceneReadyEvent.RaiseEvent(null);
            }
        }
#endif
    }
}

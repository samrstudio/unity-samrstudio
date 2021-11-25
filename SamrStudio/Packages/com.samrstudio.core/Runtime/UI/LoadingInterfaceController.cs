using SamrStudio.Core.Events;
using UnityEngine;

namespace SamrStudio.Core.UI
{
    public class LoadingInterfaceController : MonoBehaviour
    {
        [Header("Loading screen Event")]
        //The loading screen event we are listening to
        [SerializeField] private BoolEventSO _ToggleLoadingScreen = default;

        [Header("Loading screen ")]
        public GameObject loadingInterface;

        private void OnEnable()
        {
            _ToggleLoadingScreen.OnEventRaised += ToggleLoadingScreen;
        }

        private void OnDisable()
        {
            _ToggleLoadingScreen.OnEventRaised -= ToggleLoadingScreen;
        }

        private void ToggleLoadingScreen(bool state)
        {
            loadingInterface.SetActive(state);
        }
    }
}

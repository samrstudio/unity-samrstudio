using UnityEngine;
using UnityEngine.UI;
using SamrStudio.Core.Events;

namespace SamrStudio.Core.UI
{
    public class FadeController : MonoBehaviour
    {
        [SerializeField]
        private FadeEventSO fadeEventSO;
        [SerializeField]
        private Image _imageComponent;

        private void OnEnable()
        {
            fadeEventSO.OnEventRaised += InitiateFade;
        }

        private void OnDisable()
        {
            fadeEventSO.OnEventRaised -= InitiateFade;
        }

        private void InitiateFade(float duration, Color desiredColor)
        {
            //TODO: figure this out
            _imageComponent.color = desiredColor;
            //_imageComponent.DOBlendableColor(desiredColor, duration);
        }
    }
}

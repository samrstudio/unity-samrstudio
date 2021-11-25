using UnityEngine;

namespace SamrStudio.Core.Events
{
    public class TransformEventListener : MonoBehaviour
    {
        [SerializeField]
        private TransformEventSO _channel = default;

        public TransformEvent OnEventRaised;

        private void OnEnable()
        {
            if (_channel != null)
                _channel.OnEventRaised += Respond;
        }

        private void OnDisable()
        {
            if (_channel != null)
                _channel.OnEventRaised -= Respond;
        }

        private void Respond(Transform value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value);
        }
    }
}

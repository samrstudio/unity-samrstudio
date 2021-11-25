using UnityEngine;

namespace SamrStudio.Core.Events
{
    public class BoolEventListener : MonoBehaviour
    {
        [SerializeField]
        private BoolEventSO _channel = default;

        public BoolEvent OnEventRaised;

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

        private void Respond(bool value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value);
        }
    }
}

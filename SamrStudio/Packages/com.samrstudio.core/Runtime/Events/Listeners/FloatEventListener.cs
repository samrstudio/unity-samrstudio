using UnityEngine;

namespace SamrStudio.Core.Events
{
    public class FloatEventListener : MonoBehaviour
    {
        [SerializeField]
        private FloatEventSO _channel = default;

        public FloatEvent OnEventRaised;

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

        private void Respond(float value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value);
        }
    }
}

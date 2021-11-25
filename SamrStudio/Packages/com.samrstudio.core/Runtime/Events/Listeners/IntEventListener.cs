using UnityEngine;

namespace SamrStudio.Core.Events
{
    public class IntEventListener : MonoBehaviour
    {
        [SerializeField]
        private IntEventSO _channel = default;

        public IntEvent OnEventRaised;

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

        private void Respond(int value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value);
        }
    }
}

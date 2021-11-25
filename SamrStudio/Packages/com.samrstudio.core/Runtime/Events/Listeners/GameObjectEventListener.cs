using UnityEngine;

namespace SamrStudio.Core.Events
{
    public class GameObjectEventListener : MonoBehaviour
    {
        [SerializeField]
        private GameObjectEventSO _channel = default;

        public GameObjectEvent OnEventRaised;

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

        private void Respond(GameObject value)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(value);
        }
    }
}

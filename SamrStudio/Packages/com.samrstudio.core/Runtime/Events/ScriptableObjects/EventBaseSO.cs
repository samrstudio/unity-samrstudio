using UnityEngine;
using UnityEngine.Events;

namespace SamrStudio.Core.Events
{
    public abstract class EventBaseSO<T> : ScriptableObject, IEventBase<T>
    {
        [SerializeField]
        [TextArea]
        private string description;

        public UnityAction<T> OnEventRaised;

        public void RaiseEvent(T data)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(data);
        }
    }
}

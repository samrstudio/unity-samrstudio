using System;
using UnityEngine;
using UnityEngine.Events;

namespace SamrStudio.Core.Events
{
    [Serializable]
    public class GameObjectEvent : UnityEvent<GameObject>
    {
    }
}

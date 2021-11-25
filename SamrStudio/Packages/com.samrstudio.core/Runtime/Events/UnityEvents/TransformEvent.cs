using System;
using UnityEngine;
using UnityEngine.Events;

namespace SamrStudio.Core.Events
{
    [Serializable]
    public class TransformEvent : UnityEvent<Transform>
    {
    }
}

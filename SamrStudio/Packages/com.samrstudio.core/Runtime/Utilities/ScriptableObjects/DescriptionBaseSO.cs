using UnityEngine;

namespace SamrStudio.Core.Utilities
{
    public class DescriptionBaseSO : SerializableScriptableObject
    {
        [SerializeField]
        [TextArea]
        private string description;
    }
}

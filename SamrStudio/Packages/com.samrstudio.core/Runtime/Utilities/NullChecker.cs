using UnityEngine;

namespace SamrStudio.Core.Utilities
{
    public class NullChecker
    {
        public static void StopIfNull(object value, string errorMessage)
        {
            if (value == null)
            {
                Debug.LogError(errorMessage);
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            }
        }
    }
}

using UnityEngine;

namespace SamrStudio.Core.Components
{
    public class SelectedGizmo : MonoBehaviour
    {
        [SerializeField]
        internal Vector3 size = Vector3.one;
        [SerializeField]
        internal Color color = Color.red;
        [SerializeField]
        internal bool alwaysOn = false;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = color;
            Gizmos.DrawCube(transform.position, size);
        }

        private void OnDrawGizmos()
        {
            if (alwaysOn)
            {
                Gizmos.color = color;
                Gizmos.DrawCube(transform.position, size);
            }
        }
    }
}

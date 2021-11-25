using UnityEngine;

namespace SamrStudio.Core.Components
{
    /**
     * Spawn Area - component for adding an area that can return a random location within it's boundaries
     */
    public class SpawnArea : SelectedGizmo
    {
        public Vector3 GetRandomPosition()
        {
            float xSize = size.x / 2;
            float ySize = size.y / 2;
            float zSize = size.z / 2;

            return new Vector3(
                Random.Range(-xSize, xSize),
                Random.Range(-ySize, ySize),
                Random.Range(-zSize, zSize)
            );
        }

        public Vector3 GetRandomPosition2D()
        {
            float xSize = size.x / 2;
            float ySize = size.y / 2;

            return new Vector3(
                Random.Range(-xSize, xSize),
                Random.Range(-ySize, ySize),
                0
            );
        }
    }
}

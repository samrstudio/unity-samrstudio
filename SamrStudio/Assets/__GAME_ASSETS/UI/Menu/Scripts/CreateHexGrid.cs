/*===============================================================
Product:    SamrStudioTemplates
Developer:  Eric Mitchell
Company:    Samr Studio
Date:       03/12/2021 22:18
================================================================*/
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace SamrStudio
{

    [ExecuteInEditMode]
    public class CreateHexGrid : MonoBehaviour
    {
        public float outerRadius = 10f;
        public float innerRadius = 0.866025404f;

        public int width = 6;
        public int height = 6;
        public Transform hexPrefab;

        private List<Transform> hexes = new List<Transform>();

        [Button("Regenerate")]
        public void Regenerate()
        {
            if (hexPrefab != null)
            {
                innerRadius = outerRadius * 0.866025404f;
                foreach (Transform child in transform)
                {
                    DestroyImmediate(child.gameObject);
                }

                for (int z = 0, i = 0; z < height; z++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        CreateCell(x, z, i++);
                    }
                }
            }
        }

        void CreateCell(int x, int z, int i)
        {
            Vector3 position;
            position.x = (x + z * 0.5f - z / 2) * (innerRadius * 2f);
            position.y = z * (outerRadius * 1.5f);
            position.z = 0f;

            Transform hex = Instantiate(hexPrefab, transform);
            //hexes.Add(hex);
            hex.position = position;
        }
    }
}
/*===============================================================
Product:    SamrStudioTemplates
Developer:  Eric Mitchell
Company:    Samr Studio
Date:       03/12/2021 19:56
================================================================*/
using UnityEngine;

namespace SamrStudio
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(LineRenderer))]
    public class DrawScript : MonoBehaviour
    {
        private LineRenderer lineRenderer;

        [SerializeField]
        private int vertices = 6;
        [SerializeField]
        private float radius = 1;
        [SerializeField]
        private float startWidth = 1;
        [SerializeField]
        private float endWidth = 1;

        void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
            DrawPolygon(vertices, radius, transform.position, startWidth, endWidth);
        }

        private void Update()
        {
            DrawPolygon(vertices, radius, transform.position, startWidth, endWidth);
        }

        void DrawPolygon(int vertexNumber, float radius, Vector3 centerPos, float startWidth, float endWidth)
        {
            lineRenderer.startWidth = startWidth;
            lineRenderer.endWidth = endWidth;
            lineRenderer.loop = true;
            float angle = 2 * Mathf.PI / vertexNumber;
            lineRenderer.positionCount = vertexNumber;

            for (int i = 0; i < vertexNumber; i++)
            {
                Matrix4x4 rotationMatrix = new Matrix4x4(new Vector4(Mathf.Cos(angle * i), Mathf.Sin(angle * i), 0, 0),
                                                         new Vector4(-1 * Mathf.Sin(angle * i), Mathf.Cos(angle * i), 0, 0),
                                           new Vector4(0, 0, 1, 0),
                                           new Vector4(0, 0, 0, 1));
                Vector3 initialRelativePosition = new Vector3(0, radius, 0);
                lineRenderer.SetPosition(i, centerPos + rotationMatrix.MultiplyPoint(initialRelativePosition));

            }
        }
    }
}
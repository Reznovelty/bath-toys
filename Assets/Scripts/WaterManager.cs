using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class WaterManager : MonoBehaviour
{
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;

    private Vector3[] baseVertices;
    private Vector3[] displacedVertices;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();

        baseVertices = meshFilter.mesh.vertices;
        displacedVertices = new Vector3[baseVertices.Length];
    }

    private void Update()
    {
        Vector3[] vertices = meshFilter.mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y = WaveManager.instance.GetWaveHeight(transform.position.x + vertices[i].x);
        }

        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.RecalculateNormals();
    }
}

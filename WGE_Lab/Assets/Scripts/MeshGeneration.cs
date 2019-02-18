using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class MeshGeneration : MonoBehaviour
{
    Mesh mesh;
    MeshCollider meshCollider;
    List<Vector3> vertexList;
    List<int> triIndexList;
    List<Vector2> UVList;
    int numQuads = 0;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        meshCollider = GetComponent<MeshCollider>();
        vertexList = new List<Vector3>();
        triIndexList = new List<int>();
        UVList = new List<Vector2>();
        CreateQuad(1, 1, new Vector2(0, 0.5f));
        CreateQuad(2, 1, new Vector2(0.5f, 0.5f));
        mesh.vertices = vertexList.ToArray();
        mesh.triangles = triIndexList.ToArray();        mesh.uv = UVList.ToArray();        mesh.RecalculateNormals();        meshCollider.sharedMesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateQuad(int x, int y, Vector2 uvCoords)
    {
        // Add vertices to the mesh vertex list
        vertexList.Add(new Vector3(x, y + 1, 0));
        vertexList.Add(new Vector3(x + 1, y + 1, 0));
        vertexList.Add(new Vector3(x + 1, y, 0));
        vertexList.Add(new Vector3(x, y, 0));

        // Add vertex indices to the mesh tri index list
        triIndexList.Add(numQuads * 4);
        triIndexList.Add((numQuads * 4) + 1);
        triIndexList.Add((numQuads * 4) + 3);
        triIndexList.Add((numQuads * 4) + 1);
        triIndexList.Add((numQuads * 4) + 2);
        triIndexList.Add((numQuads * 4) + 3);
        numQuads++;

        UVList.Add(new Vector2(uvCoords.x, uvCoords.y + 0.5f));
        UVList.Add(new Vector2(uvCoords.x + 0.5f, uvCoords.y + 0.5f));
        UVList.Add(new Vector2(uvCoords.x + 0.5f, uvCoords.y));
        UVList.Add(new Vector2(uvCoords.x, uvCoords.y));
    }
}

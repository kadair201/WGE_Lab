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

        CreateXYQuad(1, 0, new Vector2(0.5f, 0f));
        CreateXYQuad(2, 0, new Vector2(0.5f, 0f));
        CreateXYQuad(3, 0, new Vector2(0.5f, 0f));
        CreateXYQuad(4, 0, new Vector2(0.5f, 0f));
        CreateXYQuad(5, 0, new Vector2(0.5f, 0f));
        CreateXYQuad(6, 0, new Vector2(0.5f, 0f));
        CreateXYQuad(7, 0, new Vector2(0.5f, 0f));

        CreateXYQuad(1, 1, new Vector2(0.5f, 0f));
        CreateXYQuad(2, 1, new Vector2(0.5f, 0f));
        CreateXYQuad(3, 1, new Vector2(0.5f, 0f));
        CreateXYQuad(4, 1, new Vector2(0.5f, 0f));
        CreateXYQuad(5, 1, new Vector2(0.5f, 0f));
        CreateXYQuad(6, 1, new Vector2(0.5f, 0f));
        CreateXYQuad(7, 1, new Vector2(0.5f, 0f));

        CreateXYQuad(1, 2, new Vector2(0.5f, 0f));
        CreateXYQuad(2, 2, new Vector2(0.5f, 0f));
        CreateXYQuad(3, 2, new Vector2(0.5f, 0f));
        CreateXYQuad(4, 2, new Vector2(0.5f, 0f));
        CreateXYQuad(5, 2, new Vector2(0.5f, 0f));
        CreateXYQuad(6, 2, new Vector2(0.5f, 0f));
        CreateXYQuad(7, 2, new Vector2(0.5f, 0f));

        CreateXYQuad(1, 3, new Vector2(0f, 0.5f));
        CreateXYQuad(2, 3, new Vector2(0f, 0.5f));
        CreateXYQuad(3, 3, new Vector2(0f, 0.5f));
        CreateXYQuad(4, 3, new Vector2(0f, 0.5f));
        CreateXYQuad(5, 3, new Vector2(0f, 0.5f));
        CreateXYQuad(6, 3, new Vector2(0f, 0.5f));
        CreateXYQuad(7, 3, new Vector2(0f, 0.5f));

        CreateXZQuad(1, -1, new Vector2(0f, 0f));
        CreateXZQuad(2, -1, new Vector2(0f, 0f));
        CreateXZQuad(3, -1, new Vector2(0f, 0f));
        CreateXZQuad(4, -1, new Vector2(0.5f, 0.5f));
        CreateXZQuad(5, -1, new Vector2(0f, 0f));
        CreateXZQuad(6, -1, new Vector2(0f, 0f));
        CreateXZQuad(7, -1, new Vector2(0f, 0f));

        CreateXZQuad(1, -2, new Vector2(0f, 0f));
        CreateXZQuad(2, -2, new Vector2(0f, 0f));
        CreateXZQuad(3, -2, new Vector2(0f, 0f));
        CreateXZQuad(4, -2, new Vector2(0.5f, 0.5f));
        CreateXZQuad(5, -2, new Vector2(0f, 0f));
        CreateXZQuad(6, -2, new Vector2(0f, 0f));
        CreateXZQuad(7, -2, new Vector2(0f, 0f));

        CreateXZQuad(1, -3, new Vector2(0f, 0f));
        CreateXZQuad(2, -3, new Vector2(0f, 0f));
        CreateXZQuad(3, -3, new Vector2(0f, 0f));
        CreateXZQuad(4, -3, new Vector2(0.5f, 0.5f));
        CreateXZQuad(5, -3, new Vector2(0f, 0f));
        CreateXZQuad(6, -3, new Vector2(0f, 0f));
        CreateXZQuad(7, -3, new Vector2(0f, 0f));

        CreateXZQuad(1, -4, new Vector2(0f, 0f));
        CreateXZQuad(2, -4, new Vector2(0f, 0f));
        CreateXZQuad(3, -4, new Vector2(0f, 0f));
        CreateXZQuad(4, -4, new Vector2(0.5f, 0.5f));
        CreateXZQuad(5, -4, new Vector2(0f, 0f));
        CreateXZQuad(6, -4, new Vector2(0f, 0f));
        CreateXZQuad(7, -4, new Vector2(0f, 0f));

        mesh.vertices = vertexList.ToArray();
        mesh.triangles = triIndexList.ToArray();
        mesh.uv = UVList.ToArray();
        mesh.RecalculateNormals();
        meshCollider.sharedMesh = mesh;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("hit");
            }
        }
    }

    void CreateXYQuad(int x, int y, Vector2 uvCoords)
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

    void CreateXZQuad(int x, int z, Vector2 uvCoords)
    {
        // Add vertices to the mesh vertex list
        vertexList.Add(new Vector3(x, 0, z + 1));
        vertexList.Add(new Vector3(x + 1, 0, z + 1));
        vertexList.Add(new Vector3(x + 1, 0, z));
        vertexList.Add(new Vector3(x, 0, z));

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

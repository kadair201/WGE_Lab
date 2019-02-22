﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelChunk : MonoBehaviour {

    VoxelGenerator voxelGenerator;
    int[,,] terrainArray;
    int chunkSize = 16;

    void Start()
    {
        voxelGenerator = GetComponent<VoxelGenerator>();
        // Instantiate the array with size based on chunksize
        terrainArray = new int[chunkSize, chunkSize, chunkSize];
        voxelGenerator.Initialise();
        InitialiseTerrain();
        CreateTerrain();
        voxelGenerator.UpdateMesh();
    }

    // Update is called once per frame
    void Update () {
		
	}

    void InitialiseTerrain()
    {
        // iterate horizontally on width
        for (int x = 0; x < terrainArray.GetLength(0); x++)
        {
            // iterate vertically
            for (int y = 0; y < terrainArray.GetLength(1); y++)
            {
                // iterate per voxel horizontally on depth
                for (int z = 0; z < terrainArray.GetLength(2);
                z++)
                {
                    // if we are operating on 4th layer
                    if (y == 3)
                    {
                        terrainArray[x, y, z] = 1;
                    }
                    //else if the the layer is below the fourth
                    else if (y < 3)
                    {
                        terrainArray[x, y, z] = 2;
                    }
                }
            }
        }
    }

    void CreateTerrain()
    {
        // iterate horizontally on width
        for (int x = 0; x < terrainArray.GetLength(0); x++)
        {
            // iterate vertically
            for (int y = 0; y < terrainArray.GetLength(1); y++)
            {
                // iterate per voxel horizontally on depth
                for (int z = 0; z < terrainArray.GetLength(2);
                z++)
                {
                    // if this voxel is not empty
                    if (terrainArray[x, y, z] != 0)
                    {
                        string tex;
                        // set texture name by value
                        switch (terrainArray[x, y, z])
                        {
                            case 1:
                                tex = "Grass";
                                break;
                            case 2:
                                tex = "Dirt";
                                break;
                            default:
                                tex = "Grass";
                                break;
                        }
                        voxelGenerator.CreateVoxel(x, y, z, tex);
                        print("Create " + tex + " block,");
                    }
                }
            }
        }
    }
}

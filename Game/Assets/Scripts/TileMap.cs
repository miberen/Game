﻿using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class TileMap : MonoBehaviour {

    public int sizeX = 100;
    public int sizeZ = 100;
    public float tileSize = 1.0f;

	// Use this for initialization
	void Start () {
        ConstructMesh();

	}

	// Update is called once per frame
	void Update () {
	
	}

    void ConstructTexture()
    {
        int texWidth = sizeX;
        int texHeight = sizeZ;
        Texture2D tex = new Texture2D(texWidth,texHeight);

        for(int y = 0; y < texHeight; y++){
            for(int x = 0; x < texWidth; x++){
                Color c = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                tex.SetPixel(x, y, c);
            }
        }
        tex.filterMode = FilterMode.Point;
        tex.wrapMode = TextureWrapMode.Clamp;
        tex.Apply();

        MeshRenderer mR = GetComponent<MeshRenderer>();
        mR.sharedMaterial.mainTexture = tex;     
    }

    public void ConstructMesh()
    {
        int numTiles = sizeX * sizeZ;
        int numTris = numTiles * 2;

        int vertSizeX = sizeX + 1;
        int vertSizeZ = sizeZ + 1;
        int numVerts = vertSizeX * vertSizeZ;

        //Construct mesh data
        Vector3[] vertecis = new Vector3[numVerts];
        Vector3[] normals = new Vector3[numVerts];
        Vector2[] uv = new Vector2[numVerts];

        int[] triangles = new int[numTris * 3];

        int x, z;
        for (z = 0; z < vertSizeZ; z++) {
            for (x = 0; x < vertSizeX; x++) {
                vertecis[z * vertSizeX + x] = new Vector3(x * tileSize, 0, z * tileSize);
                normals[z * vertSizeX + x] = Vector3.up;

                uv[z * vertSizeX + x] = new Vector2((float)x / sizeX, (float)z / sizeZ);
            }
        }


        for (z = 0; z < sizeZ; z++) {
            for (x = 0; x < sizeX; x++) {
                int squareIndex = z * sizeX + x;
                int triOffset = squareIndex * 6;

                triangles[triOffset + 0] = z * vertSizeX + x + 0;
                triangles[triOffset + 1] = z * vertSizeX + x + vertSizeX + 0;
                triangles[triOffset + 2] = z * vertSizeX + x + vertSizeX + 1;

                triangles[triOffset + 3] = z * vertSizeX + x + 0;
                triangles[triOffset + 4] = z * vertSizeX + x + vertSizeX + 1;
                triangles[triOffset + 5] = z * vertSizeX + x + 1;
                
            }
        }

        //Create a new Mesh and populate it with the data
        Mesh mesh = new Mesh();
        mesh.vertices = vertecis;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uv;

        //Assign the mesh to filter/render/colldier
        MeshFilter mF = GetComponent<MeshFilter>();
        MeshRenderer mR = GetComponent<MeshRenderer>();
        MeshCollider mC = GetComponent<MeshCollider>();

        mF.mesh = mesh;
        mC.sharedMesh = mesh;

        ConstructTexture();
    }
}
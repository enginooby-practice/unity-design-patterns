using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MeshGenerator
{
    public enum SHAPE { Cube, Capsule, Sphere }

    public static GameObject Create(SHAPE shape, Vector3 pos, Quaternion rot, float scale)
    {
        switch (shape)
        {
            case SHAPE.Cube:
                return CreateCube(pos, rot, scale);
        }

        return null;
    }
    public static GameObject CreateCube(Vector3 pos, Quaternion rot, float scale)
    {
        //Create an empty GameObject with the required Components
        GameObject cube = new GameObject("Cube");
        cube.AddComponent<MeshRenderer>();
        MeshFilter meshFilter = cube.AddComponent<MeshFilter>();
        Mesh mesh = meshFilter.mesh;

        //Define the cube's dimensions
        float length = scale;
        float width = scale;
        float height = scale;

        //Define the co-ordinates of each Corner of the cube 
        Vector3[] c = new Vector3[8];

        c[0] = new Vector3(-length * .5f, -width * .5f, height * .5f);
        c[1] = new Vector3(length * .5f, -width * .5f, height * .5f);
        c[2] = new Vector3(length * .5f, -width * .5f, -height * .5f);
        c[3] = new Vector3(-length * .5f, -width * .5f, -height * .5f);

        c[4] = new Vector3(-length * .5f, width * .5f, height * .5f);
        c[5] = new Vector3(length * .5f, width * .5f, height * .5f);
        c[6] = new Vector3(length * .5f, width * .5f, -height * .5f);
        c[7] = new Vector3(-length * .5f, width * .5f, -height * .5f);

        //Define the vertices that the cube is composed of:
        //used 16 vertices (4 vertices per side) to separate normals of the vertices of each side
        //(so the object renders light/shade correctly) 
        Vector3[] vertices = new Vector3[]
        {
          c[0], c[1], c[2], c[3], // Bottom
	        c[7], c[4], c[0], c[3], // Left
	        c[4], c[5], c[1], c[0], // Front
	        c[6], c[7], c[3], c[2], // Back
	        c[5], c[6], c[2], c[1], // Right
	        c[7], c[6], c[5], c[4]  // Top
        };

        //Define each vertex's UV co-ordinates
        Vector2 uv00 = new Vector2(0f, 0f);
        Vector2 uv10 = new Vector2(1f, 0f);
        Vector2 uv01 = new Vector2(0f, 1f);
        Vector2 uv11 = new Vector2(1f, 1f);

        Vector2[] uvs = new Vector2[]
        {
          uv11, uv01, uv00, uv10, // Bottom
	        uv11, uv01, uv00, uv10, // Left
	        uv11, uv01, uv00, uv10, // Front
	        uv11, uv01, uv00, uv10, // Back	        
	        uv11, uv01, uv00, uv10, // Right 
	        uv11, uv01, uv00, uv10  // Top
        };

        //Define the Polygons (triangles) that make up the our Mesh (cube)
        //IMPORTANT: Unity uses a 'Clockwise Winding Order' for determining front-facing polygons.
        //This means that a polygon's vertices must be defined in 
        //a clockwise order (relative to the camera) in order to be rendered/visible.
        int[] triangles = new int[]
        {
          3, 1, 0,        3, 2, 1,        // Bottom	
	        7, 5, 4,        7, 6, 5,        // Left
	        11, 9, 8,       11, 10, 9,      // Front
	        15, 13, 12,     15, 14, 13,     // Back
	        19, 17, 16,     19, 18, 17,	    // Right
	        23, 21, 20,     23, 22, 21,	    // Top
        };

        //Build the Mesh
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.Optimize();
        mesh.RecalculateNormals();

        //Setup new game object
        AddMaterial(cube, Color.blue);
        cube.AddComponent<BoxCollider>();
        cube.transform.position = pos;
        cube.transform.rotation = rot;

        return cube;
    }

    public static GameObject CreateCubeWithSharedMesh(Vector3 pos, Quaternion rot, float scale)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = pos;
        cube.transform.rotation = rot;
        cube.transform.localScale = Vector3.one * scale;
        AddMaterial(cube, Color.blue);
        return cube;
    }

    private static void AddMaterial(GameObject target, Color color)
    {
        Material newMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        newMaterial.SetColor("_BaseColor", color);
        target.GetComponent<Renderer>().material = newMaterial;
    }
}

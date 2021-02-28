using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubicWorldGenerator : MonoBehaviour
{
    public float noiseFactor = 1.5f;
    public int width;
    public int depth;
    public bool usePrefab;
    public GameObject cubePrefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                Vector3 pos = new Vector3(x, Mathf.PerlinNoise(x * 0.21f, z * 0.21f) * noiseFactor, z);

                if (usePrefab)
                {
                    GameObject cube = Instantiate(cubePrefab, pos, Quaternion.identity);
                }
                else
                {
                    CubeMeshGenerator.CreateCube(x * depth + z, pos);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

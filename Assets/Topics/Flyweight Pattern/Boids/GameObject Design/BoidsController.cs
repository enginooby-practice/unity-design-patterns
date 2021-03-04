using System.Collections.Generic;
using UnityEngine;

public class BoidsController : MonoBehaviour
{
    public static BoidsController Instance;

    enum MODE { None, Prefab, Scriptable_Prefab }
    [SerializeField] private MODE mode = MODE.Prefab;
    [SerializeField] private Boid[] boidPrefabs;
    [SerializeField] private BoidScriptable[] boidScriptablePrefabs;

    [Header("BOID PARAMETERS")]
    [SerializeField] private int boidAmount;
    public float boidSpeed;
    public float boidPerceptionRadius;

    [Header("FORCE PARAMETERS")]
    public float separationWeight;
    public float cohesionWeight;
    public float alignmentWeight;

    [Header("CAGE PARAMETERS")]
    public float cageSize;
    public float avoidWallsWeight;
    public float avoidWallsTurnDist;

    public List<BoidBase> boids;

    private void Awake()
    {
        Instance = this;
        boids.Clear();

        for (int i = 0; i < boidAmount; i++)
        {
            Vector3 pos = new Vector3(
                Random.Range(-cageSize / 2f, cageSize / 2f),
                Random.Range(-cageSize / 2f, cageSize / 2f),
                Random.Range(-cageSize / 2f, cageSize / 2f)
            );
            Quaternion rot = Quaternion.Euler(
                Random.Range(0f, 360f),
                Random.Range(0f, 360f),
                Random.Range(0f, 360f)
            );

            int randomIndex = Random.Range(0, boidPrefabs.Length);
            BoidBase newBoid = null;
            switch (mode)
            {
                case MODE.None:
                    break;
                case MODE.Prefab:
                    newBoid = Instantiate(boidPrefabs[randomIndex], pos, rot).GetComponent<BoidBase>();
                    break;
                case MODE.Scriptable_Prefab:
                    newBoid = Instantiate(boidScriptablePrefabs[randomIndex], pos, rot).GetComponent<BoidBase>();
                    break;
            }
            boids.Add(newBoid);
        }
    }

    public List<BoidBase> GetBoids() { return boids; }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(cageSize, cageSize, cageSize));
    }
}

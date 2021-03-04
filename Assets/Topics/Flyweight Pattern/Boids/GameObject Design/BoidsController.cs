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
        SpawnBoids();
    }

    private void SpawnBoids()
    {
        for (int i = 0; i < boidAmount; i++)
        {
            BoidBase newBoid = default;

            Vector3 randomPos = RandomPos(cageSize);
            Quaternion randomRot = RandomRot();
            int randomIndex = Random.Range(0, boidPrefabs.Length);

            switch (mode)
            {
                case MODE.None:
                    GameObject newBoidObject = MeshGenerator.Create(MeshGenerator.SHAPE.Cube, randomPos, randomRot, 1.5f);
                    newBoid = newBoidObject.AddComponent(typeof(Boid)) as Boid;

                    switch (randomIndex)
                    {
                        case 0:
                            ((Boid)newBoid).SetSharedData("Flamingo", ENDANGERED_STATUS.VU);
                            break;
                        case 1:
                            ((Boid)newBoid).SetSharedData("Shorebird", ENDANGERED_STATUS.EN);
                            break;
                        case 2:
                            ((Boid)newBoid).SetSharedData("Starling", ENDANGERED_STATUS.CR);
                            break;
                    }
                    break;
                case MODE.Prefab:
                    newBoid = Instantiate(boidPrefabs[randomIndex], randomPos, randomRot).GetComponent<BoidBase>();
                    break;
                case MODE.Scriptable_Prefab:
                    newBoid = Instantiate(boidScriptablePrefabs[randomIndex], randomPos, randomRot).GetComponent<BoidBase>();
                    break;
            }
            boids.Add(newBoid);
        }
    }

    public List<BoidBase> GetBoids() { return boids; }

    // HELPER
    public Vector3 RandomPos(float boxSize)
    {
        return new Vector3(Random.Range(-boxSize / 2f, boxSize / 2f), Random.Range(-boxSize / 2f, boxSize / 2f), Random.Range(-boxSize / 2f, boxSize / 2f));
    }

    // HELPER
    public Quaternion RandomRot()
    {
        return Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(cageSize, cageSize, cageSize));
    }
}

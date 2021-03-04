using System.Collections.Generic;
using UnityEngine;
using EPOOutline;

public class BoidsController : MonoBehaviour
{
    public static BoidsController Instance;

    [SerializeField] private int boidAmount;
    [SerializeField] private Boid[] boidPrefabs;
    public Outlinable previousOutline;

    public float boidSpeed;
    public float boidPerceptionRadius;
    public float cageSize;

    public float separationWeight;
    public float cohesionWeight;
    public float alignmentWeight;

    public float avoidWallsWeight;
    public float avoidWallsTurnDist;

    public List<Boid> boids;

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
            Boid newBoid = Instantiate(boidPrefabs[randomIndex], pos, rot).GetComponent<Boid>();
            boids.Add(newBoid);
        }
    }

    public void Hightlight(BoidBase boid)
    {
        var outlinable = boid.gameObject.AddComponent(typeof(Outlinable)) as Outlinable;
        //the Outlinable will render the Renderer we have on the gameObject we adding the Outlinable
        outlinable.OutlineTargets.Add(new OutlineTarget(boid.gameObject.GetComponent<Renderer>()));
    }

    public List<Boid> GetBoids() { return boids; }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(cageSize, cageSize, cageSize));
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "boid-shared-data", order = 51, menuName = "Boid Shared Data")]
public class BoidSharedData : ScriptableObject
{
    [SerializeField] private string specieName;
    [SerializeField] private ENDANGERED_STATUS endangeredStatus;

    public string SpecieName { get { return specieName; } }
    public ENDANGERED_STATUS EndangeredStatus { get { return endangeredStatus; } }
}

using Unity.Entities;

[GenerateAuthoringComponent]
public struct WorldGeneratorComponent : IComponentData
{
    public Entity eCubePrefab;
    public float eNoiseFactor;
    public int eWidth;
    public int eDepth;
}

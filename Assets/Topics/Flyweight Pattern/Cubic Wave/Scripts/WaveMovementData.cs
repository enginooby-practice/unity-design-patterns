using Unity.Entities;

[GenerateAuthoringComponent]
public struct WaveMovementData : IComponentData
{
    public float amplitude;
    public float xOffset;
    public float yOffset;
}
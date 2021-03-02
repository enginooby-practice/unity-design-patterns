using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class WaveSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation trans, ref WaveMovementData waveMovementData) =>
        {
            float zPos = math.sin((float)Time.ElapsedTime *5+ trans.Value.x * waveMovementData.xOffset + trans.Value.y * waveMovementData.yOffset);
            trans.Value = new float3(trans.Value.x, trans.Value.y, zPos);
        });
    }
}

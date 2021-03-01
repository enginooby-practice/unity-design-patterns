using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class WorldGeneratorSystem : SystemBase
{
    EndSimulationEntityCommandBufferSystem m_EntityCommandBufferSystem;

    protected override void OnCreate()
    {
        m_EntityCommandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
    }


    protected override void OnUpdate()
    {
   
        EntityCommandBuffer CommandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer();

        Entities.ForEach((ref LocalToWorld localToWorld, in WorldGeneratorComponent worldGeneratorComponent) =>
        {
            for (int x = 0; x < worldGeneratorComponent.eWidth; x++)
            {
                for (int z = 0; z < worldGeneratorComponent.eDepth; z++)
                {
                    var instance = CommandBuffer.Instantiate(worldGeneratorComponent.eCubePrefab);
                    var pos = math.transform(localToWorld.Value,
                        new float3(x, noise.cnoise(new float2(x, z) * 0.21f), z));
                    CommandBuffer.SetComponent(instance, new Translation { Value = pos });
                }
            }

            //destroy WorldGeneratorEntity (containing LocalToWorld & WorldGeneratorComponent) after run job once time
            //CommandBuffer.DestroyEntity(entity);
        }).Run();
    }


}

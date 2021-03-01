using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using System;
using UnityEngine;
using System.Collections.Generic;


[RequiresEntityConversion]
public class WorldGeneratorProxy : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
{
    public float noiseFactor = 1.5f;
    public int width;
    public int depth;
    public GameObject cubePrefab;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        //transfer attribute values from this game object to converted entity via a component data
        var worldGeneratorComponent = new WorldGeneratorComponent
        {
            eCubePrefab = conversionSystem.GetPrimaryEntity(cubePrefab),
            eNoiseFactor = noiseFactor,
            eWidth = width,
            eDepth = depth,
        };

        dstManager.AddComponentData(entity, worldGeneratorComponent);
    }

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(cubePrefab);
    }
}



using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[RequiresEntityConversion] // ConvertToEntity script
public class PerlinPositionProxy : MonoBehaviour, IConvertGameObjectToEntity
{

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var data = new PerlinPosition { };
        dstManager.AddComponentData(entity, data);
    }
}

public struct PerlinPosition : IComponentData { }


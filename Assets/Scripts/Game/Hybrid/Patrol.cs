using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class Patrol : MonoBehaviour, IConvertGameObjectToEntity
{
	public Entity entity;

	public Transform patrolPath;
	
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
	    DynamicBuffer<PathPointBufferElement> pointsBuffer = dstManager.AddBuffer<PathPointBufferElement>(entity);
		var points = new float3[patrolPath.childCount];
		for (int i = 0; i < points.Length; i++)
			pointsBuffer.Add(new PathPointBufferElement { value = patrolPath.GetChild(i).position });

		dstManager.AddComponentData(entity, new PatrolData() { currentIndexPoint = -1 });
		
	    this.entity = entity;
    }
}

using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolMovementSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.WithoutBurst().WithNone<AttackEventData>().ForEach((Entity entity, 
																	Transform transform, 
																	NavMeshAgent agent,
																	ref PatrolData patrolData, 
																	ref DynamicBuffer<PathPointBufferElement> buffer) =>
        {
	        if (buffer.Length == 0)
		        return;
	        float3 position = transform.position;
			if (patrolData.currentIndexPoint < 0 || patrolData.currentIndexPoint >= buffer.Length)
	        {
		        patrolData.currentIndexPoint = 0;
		        agent.SetDestination(buffer[patrolData.currentIndexPoint].value);
	        }
	        if (math.distance(buffer[patrolData.currentIndexPoint].value, position) <= 0.02f)
		    {
		        if (++patrolData.currentIndexPoint >= buffer.Length) 
			        patrolData.currentIndexPoint = 0;

		        agent.SetDestination(buffer[patrolData.currentIndexPoint].value);
			}
        }).Run();
    }
}

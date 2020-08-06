using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class BallisticsSystem : SystemBase
{
	private EndSimulationEntityCommandBufferSystem _ecbSystem;
	protected override void OnCreate()
	{
		base.OnCreate();
		_ecbSystem = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
	}

	protected override void OnUpdate()
    {
	    var commands = _ecbSystem.CreateCommandBuffer();
	    var dt = Time.DeltaTime;
		Entities.WithoutBurst().ForEach((Entity entity, ref Translation translation, ref BallisticsMovementData ballistic) =>
        {
	        var position = new float3(translation.Value);
			translation.Value = position + math.normalize(ballistic.targetPosition - position) * ballistic.speed * dt;
			if (math.distance(translation.Value, ballistic.targetPosition) < 0.2f) 
				commands.DestroyEntity(entity);
        }).Run();

		_ecbSystem.AddJobHandleForProducer(Dependency);
	}
}

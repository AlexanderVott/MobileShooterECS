using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class LifeTimeSystem : SystemBase
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
        Entities.ForEach((Entity entity, LifetimeData lifeTime) =>
        {
	        lifeTime.value -= dt;
			if (lifeTime.value <= 0f)
				commands.DestroyEntity(entity);
        }).Run();

		_ecbSystem.AddJobHandleForProducer(Dependency);
	}
}

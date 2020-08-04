using Unity.Entities;
using UnityEngine;


[DisableAutoCreation]
public class PlayerInputSystem : SystemBase
{
	private Inputs _input;
	private EndSimulationEntityCommandBufferSystem _ecbSystem;

	protected override void OnCreate()
	{
		base.OnCreate();
		_input = Inputs.instance;
		_ecbSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
    }

	protected override void OnUpdate()
	{
		var movementInput = _input.actions.Gameplay.Move.ReadValue<Vector2>();
		Entities.ForEach((Entity entity, ref PlayerInputData inputData) =>
		{
			inputData.movement = movementInput;
		}).ScheduleParallel();

		_ecbSystem.AddJobHandleForProducer(Dependency);
	}
}

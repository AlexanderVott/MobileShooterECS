using RedDev.Game.Inputs;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class PlayerInputSystem : SystemBase
{
	private InputActions _actions;
	private EndSimulationEntityCommandBufferSystem _ecbSystem;

	protected override void OnCreate()
	{
		base.OnCreate();
        _actions = new InputActions();
		_ecbSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
    }

	protected override void OnStartRunning()
	{
		base.OnStartRunning();
        _actions.Enable();
    }

	protected override void OnStopRunning()
	{
		_actions.Disable();
        base.OnStopRunning();
	}

	protected override void OnUpdate()
	{
		var movementInput = _actions.Gameplay.Move.ReadValue<Vector2>();
		Entities.ForEach((Entity entity, ref PlayerInputData inputData) =>
		{
			inputData.movement = movementInput;
			inputData.isMovement = math.lengthsq(inputData.movement) > 0.001f;
		}).ScheduleParallel();

		_ecbSystem.AddJobHandleForProducer(Dependency);
	}
}

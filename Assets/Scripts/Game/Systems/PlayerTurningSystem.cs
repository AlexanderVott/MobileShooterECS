using Unity.Entities;
using UnityEngine;

[DisableAutoCreation]
public class PlayerTurningSystem : SystemBase
{
	protected override void OnCreate()
	{
		base.OnCreate();
	}

	protected override void OnUpdate()
	{
		Entities.WithoutBurst().WithAll<PlayerData>().ForEach(
			(Entity entity, Rigidbody body, in PlayerInputData input) =>
			{
				if (input.movement.sqrMagnitude > 0.001f)
				{
					var newRotation = Quaternion.LookRotation(new Vector3(input.movement.x, 0f, input.movement.y));
					body.MoveRotation(newRotation);
				}
			}).Run();
    }
}

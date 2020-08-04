using Unity.Entities;
using UnityEngine;


[DisableAutoCreation]
public class PlayerMovementSystem : SystemBase
{
	protected override void OnUpdate()
	{
		var speed = TemplateGameDB.instance.playerSpeed;
		var dt = Time.DeltaTime;

		Entities.WithoutBurst().ForEach((Entity entity, Rigidbody body, in PlayerInputData input) =>
		{
			var move = new Vector3(input.movement.x, 0f, input.movement.y);
			move *= speed * dt;

			var go = body.gameObject;
			var position = go.transform.position;
			var newPos = new Vector3(position.x, position.y, position.z) + move;
			body.MovePosition(newPos);
		}).Run();
	}
}

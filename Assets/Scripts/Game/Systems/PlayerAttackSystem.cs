using System;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

[DisableAutoCreation]
public class PlayerAttackSystem : SystemBase
{
	private EntityManager _entityManager;
	private float _shotTime;
	private float _rateOfFire;

	private BeginSimulationEntityCommandBufferSystem _ecbSystem;

	protected override void OnStartRunning()
	{
		base.OnStartRunning();

		_entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
		_rateOfFire = TemplateGameDB.instance.playerRateOfFire;
		
		_ecbSystem = World.GetOrCreateSystem<BeginSimulationEntityCommandBufferSystem>();
	}

	protected override void OnStopRunning()
	{
		base.OnStopRunning();
	}

	protected override void OnUpdate()
	{
		var commandBuffer = _ecbSystem.CreateCommandBuffer(); 
		bool isEmpty = true;
		Vector3 nearestEnemy = Vector3.zero;
		Entity nearestEntity = Entity.Null;
		Vector3 playerPosition = Vector3.zero;
		Transform playerTransform = null;

		Entities.WithoutBurst().ForEach((Entity entity, Transform transform, in PlayerData player, in PlayerInputData inputData) =>
		{
			if (inputData.movement.sqrMagnitude > 0.002f)
				return;
			playerPosition = transform.position;
			playerTransform = transform;
		}).Run();

		Entities.WithoutBurst().WithAll<EnemyTank>().ForEach((Entity entityEnemy, Transform transformEnemy) =>
		{
			if (isEmpty)
			{
				nearestEnemy = transformEnemy.position;
				nearestEntity = entityEnemy;
				isEmpty = false;
				return;
			}

			if (Vector3.Distance(playerPosition, nearestEnemy) >
			    Vector3.Distance(playerPosition, transformEnemy.position))
			{
				nearestEnemy = transformEnemy.position;
				nearestEntity = entityEnemy;
			}
		}).Run();

		if (isEmpty || 
		    Vector3.Distance(playerPosition, nearestEnemy) > TemplateGameDB.instance.playerAttackDistance ||
		    playerTransform == null)
			return;

		Entities.WithoutBurst().WithAll<PlayerData>().ForEach((Entity entity, Rigidbody body, in PlayerInputData input) =>
		{
			body.MoveRotation(Quaternion.LookRotation(nearestEnemy - playerPosition));
		}).Run();

		Attack(commandBuffer, playerPosition + playerTransform.forward + (Vector3.up * 0.5f), nearestEnemy + (Vector3.up * 0.5f));

		_ecbSystem.AddJobHandleForProducer(Dependency);
	}

	private void Attack(EntityCommandBuffer commandBuffer, Vector3 muzzlePoint, Vector3 targetPoint)
	{
		_shotTime += Time.DeltaTime;

		if (_shotTime < _rateOfFire)
			return;

		FireBullet(commandBuffer, muzzlePoint, targetPoint);
		_shotTime = 0f;
	}

	private void FireBullet(EntityCommandBuffer commandBuffer, Vector3 muzzlePoint, Vector3 targetPoint)
	{
		var bullet = commandBuffer.Instantiate(PrefabEntities.prefabEntity);
		commandBuffer.AddComponent(bullet, new Translation { Value = muzzlePoint });
		commandBuffer.AddComponent(bullet, new Rotation { Value = Quaternion.LookRotation(targetPoint - muzzlePoint)});
		commandBuffer.AddComponent(bullet, new BallisticsMovementData { speed = TemplateGameDB.instance.bulletSpeed, targetPosition = targetPoint });

		//effects
	}
}

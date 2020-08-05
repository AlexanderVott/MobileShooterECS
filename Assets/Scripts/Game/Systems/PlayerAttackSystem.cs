using Unity.Entities;
using UnityEngine;

public class PlayerAttackSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.WithoutBurst().ForEach((Entity entity, Transform transform, in PlayerInputData inputData) =>
        {
	        if (inputData.movement.sqrMagnitude > 0.002f)
		        return;
	        var playerPosition = transform.position;
	        bool isEmpty = true;
	        Vector3 nearestEnemy = Vector3.zero;
			Entity nearestEntity = Entity.Null;
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
			    Vector3.Distance(playerPosition, nearestEnemy) > TemplateGameDB.instance.playerAttackDistance)
				return;

			//World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntity(compotype)
			Debug.Log($"Attack: {nearestEntity}");
        }).Run();
    }
}

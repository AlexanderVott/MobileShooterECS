using Unity.Entities;
using UnityEngine;

public class EnemyTank : MonoBehaviour, IConvertGameObjectToEntity
{
    public Entity entity;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
	{
		dstManager.AddComponentData(entity, new EnemyData());
		dstManager.AddComponentData(entity, new HealthData() { value = TemplateGameDB.instance.enemyHealth });

		this.entity = entity;
	}
}

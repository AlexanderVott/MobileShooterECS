using Unity.Entities;
using UnityEngine;

public class Bullet : MonoBehaviour, IConvertGameObjectToEntity
{
	private Entity entity;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
	    dstManager.AddComponentData(entity, new LifetimeData() {value = TemplateGameDB.instance.bulletLifeTime });

	    this.entity = entity;
    }
}

using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace RedDev.Game.Player
{
	public class PlayerTank : MonoBehaviour, IConvertGameObjectToEntity
	{
		public Entity entity;

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			//dstManager.AddComponentData(entity, new PlayerData());
			dstManager.AddComponentData(entity, new HealthData() { value = TemplateGameDB.instance.playerHealth });
			dstManager.AddComponentData(entity, new PlayerInputData() { movement =  float2.zero });

			this.entity = entity;
		}
	}
}
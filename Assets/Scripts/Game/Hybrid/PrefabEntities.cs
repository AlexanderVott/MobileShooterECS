using System.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class PrefabEntities : MonoBehaviour
{
	public static Entity prefabEntity;
	public static GameObject prefabReference;
	public GameObject prefabGameObject;

	void Start()
	{
		prefabReference = prefabGameObject;
		using (BlobAssetStore blobAssetStore = new BlobAssetStore())
		{
			var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
			Entity prefabEntity = GameObjectConversionUtility.ConvertGameObjectHierarchy(prefabGameObject, settings);
			PrefabEntities.prefabEntity = prefabEntity;
		}
	}
}
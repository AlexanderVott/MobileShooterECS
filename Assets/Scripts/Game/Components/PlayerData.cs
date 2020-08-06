using System;
using Unity.Entities;

[GenerateAuthoringComponent]
public struct PlayerData : IComponentData
{
	public Entity prefabEntity;
}

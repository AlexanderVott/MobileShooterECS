using System;
using Unity.Entities;

[Serializable]
public struct PatrolData : IComponentData
{
	public int currentIndexPoint;
}

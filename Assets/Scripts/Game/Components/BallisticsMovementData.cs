using Unity.Entities;
using Unity.Mathematics;

public struct BallisticsMovementData : IComponentData
{
	public float speed;
	public float3 targetPosition;
}

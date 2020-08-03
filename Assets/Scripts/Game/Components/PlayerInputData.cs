using System;
using Unity.Entities;
using Unity.Mathematics;

[Serializable]
public struct PlayerInputData : IComponentData
{
	public float2 movement;
	public bool isMovement;
}

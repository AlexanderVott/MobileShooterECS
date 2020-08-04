using System;
using Unity.Entities;
using UnityEngine;

[Serializable]
public struct PlayerInputData : IComponentData
{
	public Vector2 movement;
}

using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
[InternalBufferCapacity(4)]
public struct PathPointBufferElement : IBufferElementData
{
	public float3 value;
}

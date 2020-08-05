using Unity.Entities;
using Unity.Transforms;

public class EnemyTankAttackSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.WithoutBurst().ForEach((ref Translation translation, in Rotation rotation) => {
            
        }).Run();
    }
}

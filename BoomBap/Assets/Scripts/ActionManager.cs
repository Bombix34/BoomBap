using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public Entity PlayerEntity;
    public Entity BossEntity;

    private void ResolveActions(ActionBase playerAction, ActionBase bossAction)
    {
        var playerResolver = playerAction.Resolve(bossAction);
        var bossResolver = bossAction.Resolve(playerAction);

        this.ApplyResolver(PlayerEntity, playerResolver);
        this.ApplyResolver(BossEntity, bossResolver);
    }


    private void ApplyResolver(Entity entity, ActionResolver actionResolver)
    {
        if(actionResolver.Damage > 0)
        {
            entity.Life.DoDamage(actionResolver.Damage);
        }
    }
}

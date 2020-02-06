using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public Entity PlayerEntity;
    public Entity BossEntity;

    public void ResolveTurn()
    {
        ActionBase playerAction = PlayerEntity.CurrentAction;
        ActionBase bossAction = BossEntity.CurrentAction;
        this.ResolveActions(playerAction, bossAction);
    }

    private void ResolveActions(ActionBase playerAction, ActionBase bossAction)
    {
        var bossResolution = playerAction.Resolve(bossAction);
        var playerResolution = bossAction.Resolve(playerAction);

        this.ApplyResolver(PlayerEntity, playerResolution);
        this.ApplyResolver(BossEntity, bossResolution);
    }


    private void ApplyResolver(Entity entity, ActionResolution actionResolver)
    {
        if(actionResolver.Damage > 0)
        {
            entity.Life.DoDamage(actionResolver.Damage);
        }

        entity.NextAction();
    }
}

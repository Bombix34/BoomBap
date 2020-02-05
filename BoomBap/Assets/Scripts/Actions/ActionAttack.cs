public class ActionAttack : ActionBase, IActionLevel
{
    public int Level { get; private set; }

    protected override ActionResolver ResolveNone(ActionNone actionNone)
    {
        return this.GetApplyFullDamageResolver();
    }

    protected override ActionResolver ResolvePrepare(ActionPrepare actionPrepare)
    {
        return this.GetApplyFullDamageResolver();
    }

    protected override ActionResolver ResolveAttack(ActionAttack actionAttack)
    {
        return this.GetApplyFullDamageResolver();
    }

    protected override ActionResolver ResolveParry(ActionParry actionParry)
    {
        var damage = this.Level - actionParry.Level;

        if(damage < 0)
        {
            damage = 0;
        }

        return new ActionResolver
        {
            Damage = damage
        };
    }

    private ActionResolver GetApplyFullDamageResolver()
    {
        return new ActionResolver
        {
            Damage = Level
        };
    }
}

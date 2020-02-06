public class ActionAttack : ActionBase, IActionLevel
{
    public int Level { get; private set; }

    public ActionAttack(int level)
    {
        this.Level = level;
    }

    protected override ActionResolution ResolveNone(ActionNone actionNone)
    {
        return this.GetApplyFullDamageResolver();
    }

    protected override ActionResolution ResolvePrepare(ActionPrepare actionPrepare)
    {
        return this.GetApplyFullDamageResolver();
    }

    protected override ActionResolution ResolveAttack(ActionAttack actionAttack)
    {
        return this.GetApplyFullDamageResolver();
    }

    protected override ActionResolution ResolveParry(ActionParry actionParry)
    {
        var damage = this.Level - actionParry.Level;

        if(damage < 0)
        {
            damage = 0;
        }

        return new ActionResolution
        {
            Damage = damage
        };
    }

    private ActionResolution GetApplyFullDamageResolver()
    {
        return new ActionResolution
        {
            Damage = Level
        };
    }
}

public abstract class ActionBase
{
    public ActionResolution Resolve(ActionBase action)
    {
        ActionResolution actionResolver;
        switch (action)
        {
            case ActionNone actionNone:
                actionResolver = this.ResolveNone(actionNone);
                break;
            case ActionPrepare actionPrepare:
                actionResolver = this.ResolvePrepare(actionPrepare);
                break;
            case ActionAttack actionAttack:
                actionResolver = this.ResolveAttack(actionAttack);
                break;
            case ActionParry actionParry:
                actionResolver = this.ResolveParry(actionParry);
                break;
            default:
                throw new System.ArgumentException("Unkwown action type", nameof(action));
        }

        return actionResolver;
    }

    /// <summary>
    /// Resolve the action when against a none action
    /// </summary>
    /// <param name="actionNone">the none action against</param>
    /// <returns>An action resolver</returns>
    protected virtual ActionResolution ResolveNone(ActionNone actionNone)
    {
        return ActionResolution.Default;
    }

    /// <summary>
    /// Resolve the action when against a prepare action
    /// </summary>
    /// <param name="actionPrepare">the prepare action against</param>
    /// <returns>An action resolver</returns>
    protected virtual ActionResolution ResolvePrepare(ActionPrepare actionPrepare)
    {
        return ActionResolution.Default;
    }

    /// <summary>
    /// Resolve the action when against an attack action
    /// </summary>
    /// <param name="actionAttack">the attack action against</param>
    /// <returns>An action resolver</returns>
    protected virtual ActionResolution ResolveAttack(ActionAttack actionAttack)
    {
        return ActionResolution.Default;
    }

    /// <summary>
    /// Resolve the action when against an parry action
    /// </summary>
    /// <param name="actionParry">the parry action against</param>
    /// <returns>An action resolver</returns>
    protected virtual ActionResolution ResolveParry(ActionParry actionParry)
    {
        return ActionResolution.Default;
    }
}

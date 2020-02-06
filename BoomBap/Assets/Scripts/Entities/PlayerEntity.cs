public class PlayerEntity : Entity
{
    void Update()
    {

    }

    public override void NextAction()
    {
        this.CurrentAction = ActionNone.Default;
    }

    private void SetAction(ActionBase newAction)
    {
        if(!(CurrentAction is ActionNone))
        {
            return;
        }
        this.CurrentAction = newAction;
    }
}

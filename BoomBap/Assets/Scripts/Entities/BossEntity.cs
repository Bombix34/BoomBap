using System.Collections.Generic;

public class BossEntity : Entity
{
    public List<ActionPattern> ActionPatterns { get; set; } = new List<ActionPattern>()
    {
        new BossPatternOne(),
        new BossPatternTwo()
    };

    public List<ActionBase> Actions { get; private set; } = new List<ActionBase>();

    public override void NextAction()
    {
        if(this.Actions.Count == 0)
        {
            this.ChangePattern();
        }

        this.CurrentAction = Actions.Pop();
    }

    private void ChangePattern()
    {
        this.Actions = new List<ActionBase>(this.ActionPatterns.PickRandom().Actions);
    }
}

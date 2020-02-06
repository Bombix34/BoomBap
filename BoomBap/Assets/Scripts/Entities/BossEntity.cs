using System.Collections.Generic;

public class BossEntity : Entity
{
    public List<ActionPattern> ActionPatterns { get; set; } = new List<ActionPattern>()
    {
        new BossPatternOne(),
        new BossPatternTwo()
    };

    private List<ActionBase> actions;

    public override void NextAction()
    {
        if(this.actions.Count == 0)
        {
            this.ChangePattern();
        }

        this.CurrentAction = actions.Pop();
    }

    private void ChangePattern()
    {
        this.actions = this.ActionPatterns.PickRandom().Actions;
    }
}

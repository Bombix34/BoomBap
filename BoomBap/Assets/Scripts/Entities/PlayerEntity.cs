using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : Entity
{
    public int ComboCount => actionsCombo.Count; 

    private List<ActionBase> actionsCombo = new List<ActionBase>();

    protected override void Start()
    {
        base.Start();
        this.CurrentAction = ActionNone.Default;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            this.SetAction(new ActionAttack(1));
        }
        if (Input.GetButtonDown("Fire2"))
        {
            this.SetAction(new ActionParry(10));
        }
    }

    public override void NextAction()
    {
        if(CurrentAction is ActionNone)//Si l'action précédente etait déjà actionNone
        {
            this.CancelCombo();
        }
        this.CurrentAction = ActionNone.Default;
    }

    private void SetAction(ActionBase newAction)
    {
        if (!(CurrentAction is ActionNone))//Si le joueur fait une deuxième action dans son tour
        {
            this.CancelCombo();
            this.CurrentAction = ActionNone.Default;
            return;
        }

        this.CurrentAction = newAction;
        this.actionsCombo.Add(this.CurrentAction);
    }

    private void CancelCombo()
    {
        this.actionsCombo.Clear();
    }


}

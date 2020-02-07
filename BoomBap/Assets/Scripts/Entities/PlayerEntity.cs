using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : Entity
{
    public int ComboCount => actionsCombo.Count; 

    private List<ActionBase> actionsCombo = new List<ActionBase>();
    private bool alreadyPlayedThisTurn = false;

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
        this.alreadyPlayedThisTurn = false;
    }

    private void SetAction(ActionBase newAction)
    {
        if (!(CurrentAction is ActionNone))//Si le joueur fait une deuxième action dans son tour
        {
            this.OnPlayerActionError();
            return;
        }
        if (this.alreadyPlayedThisTurn)
        {
            return;
        }

        var inputResolution = TickManager.Instance.GetInputResolution();

        switch (inputResolution)
        {
            case TickManager.InputResolution.bad:
                this.OnPlayerActionError();
                return;
            case TickManager.InputResolution.average:
                break;
            case TickManager.InputResolution.perfect:
                break;
            default:
                throw new System.ArgumentException($"Unknown value {inputResolution.ToString()}", nameof(inputResolution));
        }

        this.CurrentAction = newAction;
        this.actionsCombo.Add(this.CurrentAction);
        this.alreadyPlayedThisTurn = true;
    }

    private void OnPlayerActionError()
    {
        this.CancelCombo();
        this.CurrentAction = ActionNone.Default;
    }

    private void CancelCombo()
    {
        this.actionsCombo.Clear();
    }


}

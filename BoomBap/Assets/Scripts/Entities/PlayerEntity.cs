using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : Entity
{
    public int ComboCount => actionsCombo.Count;

    private BattleInputsManager m_inputs;

    private List<ActionBase> actionsCombo = new List<ActionBase>();
    private bool alreadyPlayedThisTurn = false;

    protected override void Start()
    {
        base.Start();
        m_inputs = this.GetComponent<BattleInputsManager>();
        this.CurrentAction = ActionNone.Default;
    }

    void Update()
    {
        InputsUpdate();
    }

    private void InputsUpdate()
    {
        if(m_inputs.ActionInputDown(BattleInputsManager.ActionInput.bottom))
        {
            this.SetAction(new ActionAttack(1));
            print("bottom");
        }
        if (m_inputs.ActionInputDown(BattleInputsManager.ActionInput.top))
        {
            print("top");
        }
        if (m_inputs.ActionInputDown(BattleInputsManager.ActionInput.right))
        {
            this.SetAction(new ActionParry(10));
            print("right");
        }
        if (m_inputs.ActionInputDown(BattleInputsManager.ActionInput.left))
        {
            this.SetAction(new ActionParry(10));
            print("left");
        }
        if(m_inputs.StartInputDown)
        {
            print("start");
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
        BpmUI.Instance.SwitchColor(Color.white);
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
            BpmUI.Instance.SwitchColor(Color.red);
            return;
        }

        var inputResolution = TickManager.Instance.GetInputResolution();

        switch (inputResolution)
        {
            case TickManager.InputResolution.bad:
                this.OnPlayerActionError();
                BpmUI.Instance.SwitchColor(Color.red);
                return;
            case TickManager.InputResolution.average:
                BpmUI.Instance.SwitchColor(Color.yellow);
                break;
            case TickManager.InputResolution.perfect:
                BpmUI.Instance.SwitchColor(Color.green);
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

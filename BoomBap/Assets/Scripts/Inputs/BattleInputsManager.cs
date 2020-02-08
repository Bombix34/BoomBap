using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleInputsManager : InputsManager
{
    protected override void Awake()
    {
        base.Awake();
    }

    public bool ActionInputDown(ActionInput input)
    {
        switch(input)
        {
            case ActionInput.bottom:
                return m_player.GetButtonDown("BottomAction");
            case ActionInput.top:
                return m_player.GetButtonDown("TopAction");
            case ActionInput.left:
                return m_player.GetButtonDown("LeftAction");
            case ActionInput.right:
                return m_player.GetButtonDown("RightAction");
            default:
                return m_player.GetButtonDown("BottomAction");
        }
    }

    public enum ActionInput
    {
        bottom,
        top,
        left,
        right
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionUIManager : MonoBehaviour
{
    public ActionUI playerActionUI;
    public List<ActionUI> bossActionsUI;

    // Update is called once per frame
    void Update()
    {
        this.playerActionUI.action = ActionManager.Instance.PlayerEntity.CurrentAction;
        this.bossActionsUI[0].action = ActionManager.Instance.BossEntity.CurrentAction;
        var actions = ActionManager.Instance.BossEntity.Actions;
        for (int i = 1; i < bossActionsUI.Count; i++)
        {
            if(actions.Count >= i)
            {
                this.bossActionsUI[i].action = actions[i - 1];
            }
            else
            {
                this.bossActionsUI[i].action = null;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    public Text lifePointText;
    private Entity entity;
    public bool isPlayerEntity;

    void Start()
    {
        if (isPlayerEntity)
        {
            this.entity = ActionManager.Instance.PlayerEntity;
        }
        else
        {
            this.entity = ActionManager.Instance.BossEntity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.lifePointText.text = this.entity.Life.LifePoint.ToString();
    }
}

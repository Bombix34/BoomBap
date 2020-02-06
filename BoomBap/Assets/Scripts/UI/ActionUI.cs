using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionUI : MonoBehaviour
{
    public Text actionText;
    public ActionBase action = ActionNone.Default;

    // Update is called once per frame
    void Update()
    {
        this.actionText.text = action.ToString();
    }
}

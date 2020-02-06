using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionUI : MonoBehaviour
{
    public Text actionText;
    public ActionBase action = ActionNone.Default;

    private Image panelImage;
    void Start()
    {
        this.panelImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(action != null)
        {
            this.actionText.text = action.ToString();
            this.panelImage.enabled = true;
            this.actionText.enabled = true;
        }
        else
        {
            this.panelImage.enabled = false;
            this.actionText.enabled = false;
        }
    }
}

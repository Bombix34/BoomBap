using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BpmUI : Singleton<BpmUI>
{
    [SerializeField]
    private BpmUISettings m_settings;

    private Image m_cadre;

    private void Start()
    {
        m_cadre = this.GetComponent<Image>();
        SwitchColor(Color.white);
        m_cadre.DOFade(0f, 0f);
        TickManager.Instance.OnTickEvent.AddListener(Feedback);
    }

    public void Feedback()
    {
        m_cadre.DOFade(m_settings.AlphaOnBeat, 0f);
        m_cadre.DOFade(0f, m_settings.FadeSpeed);
    }

    public void SwitchColor(Color newColor)
    {
        m_cadre.DOColor(newColor, 0f);
    }

}

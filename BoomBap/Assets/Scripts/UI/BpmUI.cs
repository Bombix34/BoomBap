using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BpmUI : MonoBehaviour
{
    [SerializeField]
    private BpmUISettings m_settings;

    private Image m_cadre;

    private void Start()
    {
        m_cadre = this.GetComponent<Image>();
        TickManager.Instance.OnTickEvent.AddListener(Feedback);
    }

    public void Feedback()
    {
        m_cadre.DOFade(m_settings.AlphaOnBeat, 0f);
        m_cadre.DOFade(0f, m_settings.FadeSpeed);

    }
}

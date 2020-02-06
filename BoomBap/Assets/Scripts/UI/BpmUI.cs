using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BpmUI : MonoBehaviour
{
    [SerializeField]
    private BpmUISettings m_settings;

    private Image m_cadre;

    private void Start()
    {
        m_cadre = this.GetComponent<Image>();
    }

    public void Feedback()
    {
        StartCoroutine(LaunchFeedback());
    }

    private IEnumerator LaunchFeedback()
    {
        float alphaAmount = m_settings.AlphaOnBeat;
        m_cadre.color = new Color(m_cadre.color.r, m_cadre.color.g, m_cadre.color.b, alphaAmount);
        while (m_cadre.color.a > 0f)
        {
            m_cadre.color = new Color(m_cadre.color.r, m_cadre.color.g, m_cadre.color.b, alphaAmount);
            alphaAmount -= (Time.fixedDeltaTime*m_settings.FadeSpeed);
            yield return new WaitForEndOfFrame();
        }
    }
}

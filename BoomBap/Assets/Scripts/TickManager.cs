using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickManager : MonoBehaviour
{
    [SerializeField]
    private MusicDatas m_currentMusic;
    private float m_waitTime=10f;
    private float m_timeInterval;
    private bool isLaunch = false;

    private float m_timeSinceLastTick=0f;

    [SerializeField]
    private BpmUI m_bpmUI;

    [SerializeField]
    private AudioSource m_audioSource;

    private void Start()
    {
        m_waitTime = m_currentMusic.StartTime;
        m_timeInterval = m_currentMusic.TimeInterval;
        StartMusic();
    }

    private void Update()
    {
        WaitForMusicStart();
        CalculateTime();
        CheckTickEvent();
    }

    private void StartMusic()
    {
        m_audioSource.clip = m_currentMusic.Song;
        m_audioSource.Play();
    }

    private void WaitForMusicStart()
    {
        if (isLaunch)
            return;
        if (Time.timeSinceLevelLoad>=m_currentMusic.StartTime)
        {
            TickEvent();
            isLaunch = true;   
        }
    }

    private void CalculateTime()
    {
        if (!isLaunch)
            return;
        m_timeSinceLastTick += Time.deltaTime;
    }

    private void CheckTickEvent()
    {
        if(m_timeSinceLastTick>=m_timeInterval)
        {
            m_timeSinceLastTick = 0f;
            TickEvent();
        }
    }

    private void TickEvent()
    {
        m_bpmUI.Feedback();
    }
}

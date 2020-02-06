using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickManager : Singleton<TickManager>
{
    [SerializeField]
    private MusicDatas m_currentMusic;
    [SerializeField]
    private BpmUI m_bpmUI;
    [SerializeField]
    private AudioSource m_audioSource;

    //The number of seconds for each song beat
    private float m_secPerBeat;

    //Current song position, in seconds
    private float m_songPositionSinceStart;
    private float m_songPositionSinceBeat;

    //Current song position, in beats
    public float m_songPositionInBeats;

    private float m_prevSongPositionInBeats=0f;

    //How many seconds have passed since the song started
    public float m_songStartTime;

    public float test = 0f;

    private void Start()
    {
        m_audioSource.clip = m_currentMusic.Song;

        //Calculate the number of seconds in each beat
        m_secPerBeat = 60f /m_currentMusic.BPM;

        //Record the time when the music starts
        m_songStartTime = (float)AudioSettings.dspTime;

        m_audioSource.Play();
    }

    private void Update()
    {
        //determine how many seconds since the song started
        m_songPositionSinceStart = (float)(AudioSettings.dspTime - m_songStartTime);

        if(m_songPositionSinceStart<m_currentMusic.StartTime)
        {
            return;
        }
        m_songPositionSinceBeat = (float)(AudioSettings.dspTime - m_songStartTime);
        //determine how many beats since the song started
        m_songPositionInBeats = m_songPositionSinceBeat / m_secPerBeat;
        if ((int)m_songPositionInBeats != (int)m_prevSongPositionInBeats)
        {
            m_prevSongPositionInBeats = m_songPositionInBeats;
            TickEvent();
        }
    }

    private void TickEvent()
    {
        m_bpmUI.Feedback();
        ActionManager.Instance.ResolveTurn();
    }

    #region GET/SET

    public MusicDatas SongDatas { get => m_currentMusic; }

    public AudioSource SourceAudio { get => m_audioSource; }

    public float TimeSinceSongStart { get => m_songPositionSinceStart; }

    #endregion
}

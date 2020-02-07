using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TickManager : Singleton<TickManager>
{
    [SerializeField]
    private MusicDatas m_currentMusic;

    [SerializeField]
    private InputSettings m_inputSettings;

    private AudioSource m_audioSource;
    private UnityEvent m_onTickEvent;

    //The number of seconds for each song beat
    private float m_secPerBeat;

    //Current song position, in seconds
    private float m_songPositionSinceStart;
    private float m_songPositionSinceBeat=0f;

    //Current song position, in beats
    private float m_songPositionInBeats;

    private float m_prevSongPositionInBeats=0f;

    private float m_curBeatPositionInSec;
    private float m_nextBeatPositionInSec;

    //How many seconds have passed since the song started
    private float m_songStartTime;

    private void Awake()
    {
        m_onTickEvent = new UnityEvent();
        m_audioSource = gameObject.AddComponent<AudioSource>();
        m_audioSource.volume = 0.3f;
    }

    private void Start()
    {
        m_onTickEvent.AddListener(ResetBeatPositionOnTick);
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

        if(m_songPositionSinceStart < m_currentMusic.StartTime)
        {
            return;
        }
        m_songPositionSinceBeat = (float)(AudioSettings.dspTime - m_songStartTime );

        //determine how many beats since the beat started
        m_songPositionInBeats = m_songPositionSinceBeat / m_secPerBeat;
        if((int)m_prevSongPositionInBeats==0)
        {
            m_prevSongPositionInBeats = m_songPositionInBeats;
        }

        if ((int)m_songPositionInBeats != (int)m_prevSongPositionInBeats)
        {
            TickEvent();
        }
    }

    private void ResetBeatPositionOnTick()
    {
        m_prevSongPositionInBeats = m_songPositionInBeats;
        m_curBeatPositionInSec = m_songPositionSinceBeat;
        m_nextBeatPositionInSec = m_curBeatPositionInSec + m_secPerBeat;
    }

    private void TickEvent()
    {
        m_onTickEvent.Invoke();
    }
    public InputResolution GetInputResolution()
    {
        return this.GetInputResolution(this.CurrentBeat);
    }

    public InputResolution GetInputResolution(float lastBeatInput)
    {
        InputResolution resolution = InputResolution.bad;
        float currentTime = TimeSinceBeatStart;
        float perfectTimePositive=1000f;
        float perfectTimeNegative= 1000f;
        float averageTimePositive=1000F;
        float averageTimeNegative = 1000F;
        if (Mathf.Abs(currentTime-m_curBeatPositionInSec)<Mathf.Abs(currentTime-m_nextBeatPositionInSec))
        {
            if (lastBeatInput != m_curBeatPositionInSec)
            {
                perfectTimePositive = m_curBeatPositionInSec + m_secPerBeat * m_inputSettings.perfectTickTolerance;
                perfectTimeNegative = m_curBeatPositionInSec - (m_secPerBeat * m_inputSettings.perfectTickTolerance);
                averageTimePositive = m_curBeatPositionInSec + m_secPerBeat * m_inputSettings.averageTickTolerance;
                averageTimeNegative = m_curBeatPositionInSec - (m_secPerBeat * m_inputSettings.perfectTickTolerance);
            }
        }
        else
        {
            if (lastBeatInput != m_nextBeatPositionInSec)
            {
                perfectTimePositive = m_nextBeatPositionInSec + m_secPerBeat * m_inputSettings.perfectTickTolerance;
                perfectTimeNegative = m_nextBeatPositionInSec - (m_secPerBeat * m_inputSettings.perfectTickTolerance);
                averageTimePositive = m_nextBeatPositionInSec + m_secPerBeat * m_inputSettings.averageTickTolerance;
                averageTimeNegative = m_nextBeatPositionInSec - (m_secPerBeat * m_inputSettings.perfectTickTolerance);
            }
        }
        if(currentTime<perfectTimePositive && currentTime>perfectTimeNegative)
        {
            resolution = InputResolution.perfect;
        }
        else if(currentTime<averageTimePositive && currentTime>averageTimeNegative)
        {
            resolution = InputResolution.average;
        }
        print("beat time: " + m_curBeatPositionInSec);
        print("current time: "+currentTime);
        print("perfect time: " + perfectTimePositive);
        print("average time: " + averageTimePositive);
        print("resolution: " + resolution);
        print("-----------");
        // Debug.Break();
        return resolution;
    }


    #region GET/SET

    public MusicDatas SongDatas { get => m_currentMusic; }

    public AudioSource SourceAudio { get => m_audioSource; }

    public float TimeSinceSongStart { get => m_songPositionSinceStart; }

    public float TimeSinceBeatStart { get => m_songPositionSinceBeat; }

    public UnityEvent OnTickEvent { get => m_onTickEvent; }

    public int CurrentBeat { get => (int)m_songPositionInBeats; }

    #endregion

    public enum InputResolution
    {
        bad,
        average,
        perfect
    }
}

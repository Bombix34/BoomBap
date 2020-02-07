using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestBpm : MonoBehaviour
{

    private TickManager tickManager;

    [SerializeField]
    private InputSettings playerInputSettings;

    private List<float> timesInputList;

    [SerializeField]
    private bool isRecordingBpm = false;

    [SerializeField]
    private float startTime = 0f;
    private bool startIsSetup = false;
    [SerializeField]
    private float timeInterval = 0f;

    [SerializeField]
    private Text textBPM;
    [SerializeField]
    private Text startTimeText;

    [SerializeField]
    private Text inputFeedbackText;

    private int lastBeatInput = -100;

    private void Start()
    {
        textBPM.text = "";
        startTimeText.text = "";
        timesInputList = new List<float>();
        tickManager = GetComponent<TickManager>();
    }

    private void Update()
    {
        TryInputBeat();
        if (Input.GetKeyDown(KeyCode.B))
        {
            timesInputList.Add((tickManager.TimeSinceSongStart));
            ShowBPM((int)CalculateBPM());
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            startIsSetup = true;
            startTime = tickManager.TimeSinceSongStart;
            ShowStartTime();
        }
    }

    private void TryInputBeat()
    {
        if(Input.GetKeyDown(KeyCode.Space) && tickManager.TimeSinceBeatStart>=0)
        {
            if(tickManager.CurrentBeat!=lastBeatInput)
            {
                lastBeatInput = tickManager.CurrentBeat;
                inputFeedbackText.text = tickManager.GetInputResolution().ToString();
            }
            else
            {
                inputFeedbackText.text = "already tapped";
            }
        }
    }

    private float CalculateBPM()
    {
        if(timesInputList.Count<2)
        {
            return 0f;
        }
        float deltaTime=0f;
        for(int i = 0; i < timesInputList.Count-1; ++i)
        {
            deltaTime += timesInputList[i + 1] - timesInputList[i];
        }
        timeInterval = deltaTime / (timesInputList.Count);
        deltaTime = 60f / timeInterval;
        if(isRecordingBpm)
        {
            tickManager.SongDatas.BPM = (int)deltaTime;
        }
        return deltaTime;
    }

    private void ShowBPM(int bpm)
    {
        textBPM.text = bpm.ToString();
    }

    private void ShowStartTime()
    {
        startTimeText.text = startTime.ToString();
    }
}

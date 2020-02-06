using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestBpm : MonoBehaviour
{
    private float[] timesInput;
    private int index = 0;

    [SerializeField]
    private float startTime = 0f;
    private bool startIsSetup = false;
    [SerializeField]
    private float timeInterval = 0f;

    private Text textBPM;
    [SerializeField]
    private Text startTimeText;

    private void Start()
    {
        textBPM = GetComponent<Text>();
        textBPM.text = "";
        startTimeText.text = "";
        timesInput = new float[2] { 0f, 0f };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            timesInput[index] = Time.timeSinceLevelLoad;
            index++;
            if (index >= timesInput.Length)
            {
                index = 0;
            }
            ShowBPM((int)CalculateBPM());
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            startIsSetup = true;
            startTime = Time.timeSinceLevelLoad;
            ShowStartTime(startTime);
        }
    }

    private float CalculateBPM()
    {
        float deltaTime=0f;
        timeInterval = index == 0 ? timesInput[1] - timesInput[0] : timesInput[0] - timesInput[1];
        deltaTime = 60f / timeInterval;
        return deltaTime;
    }

    private void ShowBPM(int bpm)
    {
        textBPM.text = bpm.ToString();
    }

    private void ShowStartTime(float startTime)
    {
        startTimeText.text = startTime.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BpmUISettings", menuName ="BoomBap/BpmUISettings")]
public class BpmUISettings : ScriptableObject
{
    [SerializeField]
    [Range(0f,1f)]
    private float m_alphaOnBeat=0.9f;
    public float AlphaOnBeat { get => m_alphaOnBeat; }

    [SerializeField]
    private float m_fadeSpeed=1f;
    public float FadeSpeed { get => m_fadeSpeed; }
}
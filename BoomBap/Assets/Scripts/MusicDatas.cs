using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new music data", menuName = "BoomBap/new music datas")]
public class MusicDatas : ScriptableObject
{
    [SerializeField]
    private AudioClip m_song;
    public AudioClip Song { get => m_song; }

    [SerializeField]
    [Range(50,160)]
    private int m_BPM = 80;
    public int BPM { get => m_BPM; set { m_BPM = value; } }

    [SerializeField]
    private float m_startTime;
    public float StartTime { get => m_startTime; }
}

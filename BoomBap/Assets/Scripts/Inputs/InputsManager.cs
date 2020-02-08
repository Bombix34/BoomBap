using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class InputsManager : MonoBehaviour
{
    // The Rewired player id of this character
    [SerializeField]
    protected int m_playerId = 0;

    protected Player m_player; // The Rewired Player

    protected virtual void Awake()
    {
        // Get the Rewired Player object for this player and keep it for the duration of the character's lifetime
        m_player = ReInput.players.GetPlayer(m_playerId);
    }

    //Start
    public bool StartInputDown
    {
        get => m_player.GetButtonDown("Start");
    }
    public bool StartInputUp
    {
        get => m_player.GetButtonUp("Start");
    }

    //Any
    public bool PressAnyButtonDown
    {
        get => m_player.GetAnyButtonDown();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSettings : ScriptableObject
{
    [Range(0f, 1f)]
    public float perfectTickTolerance = 0f;
    [Range(0f, 1F)]
    public float averageTickTolerance = 0f;
}

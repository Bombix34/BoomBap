using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSettings : ScriptableObject
{
    [Range(0f, 0.5f)]
    public float perfectTickTolerance = 0f;
    [Range(0f, 0.5F)]
    public float averageTickTolerance = 0f;
}

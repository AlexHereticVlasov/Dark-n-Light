using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public SomeValues[] SomeValues;
}

[System.Serializable]
public class SomeValues
{
    public float Value1;
    public float Value2;
    public float Value3;
}

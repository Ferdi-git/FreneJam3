using System;
using UnityEngine;

[CreateAssetMenu]
public class SOEventGame : ScriptableObject
{
    public event Action SpikeCheck;

    public void InvokeSpikeCheck()
    {
        SpikeCheck?.Invoke();
    }


}

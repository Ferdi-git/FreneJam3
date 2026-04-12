using System;
using UnityEngine;

public class SOEventGame : MonoBehaviour
{
    public event Action SpikeCheck;

    public void InvokeSpikeCheck()
    {
        SpikeCheck.Invoke();
    }


}

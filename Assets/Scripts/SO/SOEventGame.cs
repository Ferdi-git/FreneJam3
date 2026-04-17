using System;
using UnityEngine;

[CreateAssetMenu]
public class SOEventGame : ScriptableObject
{
    public event Action SpikeCheck;
    public event Action Win;
    public event Action<int> PointWon;

    public void InvokeSpikeCheck()
    {
        SpikeCheck?.Invoke();
    }
    public void InvokePointWon(int i)
    {
        PointWon?.Invoke(i);
    }

    public void InvokeWin()
    {
        Win?.Invoke();
    }
}

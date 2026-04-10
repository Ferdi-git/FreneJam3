using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ZoneDetect : MonoBehaviour
{
    public float min;
    public float max;
    [SerializeField] AnimateLoudness loudness;

    private SpriteRenderer sprite; [SerializeField] Queue<float> oldLoudness = new Queue<float>();
    [SerializeField] int nbrToCheck = 10;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        AddToElementStack(loudness.Size());
        if (loudness.Size() > min && loudness.Size() < max)
        {
            sprite.color = Color.green;
        }
        else
        {
            sprite.color = Color.red;
        }
    }



    public bool CheckIfOnIt()
    {
        if (GetMoyenne() > min && GetMoyenne() < max)
        {
            return true;
        }
        return false;
    }


    private float GetMoyenne()
    {
        float total = 0;
        int nbrElement = 1;
        for (int i = 0; i < oldLoudness.Count; i++)
        {
            total += oldLoudness.ElementAt(i);
            if (i != 0) nbrElement++;
        }
        total = total / (float)nbrElement;
        return total;
    }


    private void AddToElementStack(float element)
    {
        oldLoudness.Enqueue(element);
        if (oldLoudness.Count > nbrToCheck) { oldLoudness.Dequeue(); }
    }
}

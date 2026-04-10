using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimateLoudness : MonoBehaviour
{
    //Vector3 minSize;
    //[SerializeField] Vector3 maxSize;
    [SerializeField] VoiceDetector voiceDetector;
    [SerializeField] float mult = 100;
    [SerializeField] int nbrFile = 5;
    [SerializeField] Queue<float> oldLoudness = new Queue<float>();

    [SerializeField] private float loudness;
    [SerializeField] private float moyenne;

    //[SerializeField] private float[] values;
    void Start()
    {
        //minSize = transform.localScale;
    }

    [ContextMenu("Test")]
    private void TestStack()
    {
        var rnd = Random.Range(0, 10);
        print(rnd);
        AddToElementStack(rnd);
    }

    void FixedUpdate()
    {
        loudness = voiceDetector.GetSamplesFromAudio(Microphone.GetPosition(Microphone.devices[0]), voiceDetector.clip) * mult;
        AddToElementStack(loudness);
        //print(loudness);


        moyenne = GetMoyenne();
        //transform.localScale = Vector3.Lerp(minSize, maxSize, moyenne < 0.15f ? 0 : moyenne);
        transform.localScale = new Vector3(moyenne, moyenne, moyenne);
    }

    public float Size()
    {
        return transform.localScale.x;
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
        if(oldLoudness.Count > nbrFile) { oldLoudness.Dequeue(); }
    }
}

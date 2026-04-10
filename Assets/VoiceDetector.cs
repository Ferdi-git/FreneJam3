using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VoiceDetector : MonoBehaviour
{
    [SerializeField] int samples = 64;
    [HideInInspector] public AudioClip clip;

    void Start()
    {
        clip = Microphone.Start(Microphone.devices[0], true , 10 , 44100);
    }


    public float GetSamplesFromAudio(int pos,AudioClip clip)
    {
        float[] audioData = new float[samples];
        int startPos = pos- samples;
        float loudness = 0;

        clip.GetData(audioData, startPos < 0 ? 0 : startPos);
        foreach(float data in audioData)
        {
            loudness += Mathf.Abs(data);
        }
        return loudness/samples;
    }

}

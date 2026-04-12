using UnityEngine;

public class VoiceDetector : MonoBehaviour
{
    [SerializeField] int samples = 64;
    [HideInInspector] public AudioClip clip;

    void Start()
    {
        clip = Microphone.Start(Microphone.devices[0], true, 10, 44100);
    }

    public float GetSamplesFromAudio(int pos, AudioClip clip)
    {
        float[] audioData = new float[samples];
        int startPos = pos - samples;

        if (clip == null || pos < samples)
            return 0f;

        clip.GetData(audioData, startPos);

        float loudness = 0f;
        foreach (float data in audioData)
            loudness += Mathf.Abs(data);

        return loudness / samples;
    }
}
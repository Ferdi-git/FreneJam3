using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimateLoudness : MonoBehaviour
{
    [SerializeField] VoiceDetector voiceDetector;
    [SerializeField] SOEventGame eventGame;
    [SerializeField] float mult = 100f;
    [SerializeField] int nbrFile = 5;
    [SerializeField] float spikeThresholdMultiplier = 2.5f;
    [SerializeField] float spikeMinAbsolute = 0.3f;
    [SerializeField] float spikeCooldown = 0.5f;
    [SerializeField] float baselineLerp = 0.02f; 

    private Queue<float> oldLoudness = new Queue<float>();
    private float loudness;
    private float moyenne;
    [SerializeField] private float moyenneMax;
    private float baseline = 0f;  
    private float lastSpikeTime = -999f;

    void FixedUpdate()
    {
        loudness = voiceDetector.GetSamplesFromAudio(
            Microphone.GetPosition(Microphone.devices[0]),
            voiceDetector.clip) * mult;

        baseline = Mathf.Lerp(baseline, loudness, baselineLerp);  

        AddToElementStack(loudness);
        moyenne = GetMoyenne();
        if (DetectSpike(loudness, moyenne))
        {
            Debug.Log("Spike");
            OnSpikeDetected();
        }
        if(moyenne > moyenneMax) moyenne = moyenneMax;
        transform.localScale = new Vector3(moyenne, moyenne, moyenne);
    }

    public float Size()
    {
        return transform.localScale.x;
    }

    private float GetMoyenne()
    {
        if (oldLoudness.Count == 0) return 0f;
        return oldLoudness.Sum() / oldLoudness.Count;
    }

    private void AddToElementStack(float element)
    {
        oldLoudness.Enqueue(element);
        if (oldLoudness.Count > nbrFile)
            oldLoudness.Dequeue();
    }

    private bool DetectSpike(float current, float average)
    {
        if (Time.time - lastSpikeTime < spikeCooldown) return false;
        if (current < spikeMinAbsolute) return false;
        if (current >= baseline * spikeThresholdMultiplier) 
        {
            lastSpikeTime = Time.time;
            return true;
        }
        return false;
    }

    private void OnSpikeDetected()
    {
        eventGame.InvokeSpikeCheck();
    }
}
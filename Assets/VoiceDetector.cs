using UnityEngine;

public class VoiceDetector : MonoBehaviour
{
    [SerializeField] int samples = 64;
    [HideInInspector] public AudioClip clip;

    void Start()
    {
        clip = Microphone.Start(Microphone.devices[0], true , 10 , 44100);
    }



}

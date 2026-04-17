using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private SOEventGame eventGame;

    private void Start()
    {
        slider.value = 30;
    }

    private void Update()
    {
        slider.value -= Time.deltaTime;
        if(slider.value <= 0)
        {
            slider.value = 0;
            eventGame.InvokeWin();
        }
    }

}

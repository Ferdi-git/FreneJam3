using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TextMeshPro textMeshPro;
    private int nbr = 0 ;
    private bool isAlive = true;

    [SerializeField] TypeEvent[] listEvents;




    void Start()
    {
        textMeshPro.text = nbr.ToString();
        StartCoroutine(Game());
        StartCoroutine(Kill());
    }

    private IEnumerator Kill()
    {
        yield return new WaitForSeconds(600);
        isAlive = false;
    }

    private IEnumerator Game()
    {
        while (isAlive)
        {
            yield return new WaitForSeconds(3);


        }

    }

    private void InvokeEvent(TypeEvent tEvent)
    {
        switch(tEvent)
        {
            case TypeEvent.simpleNote:
                break;
            case TypeEvent.fastNote:
                break ;
            case TypeEvent.slowNote:
                break ;
            case TypeEvent.simpleZoneDetect:
                break ;
            case TypeEvent.bigZoneDetect:
                break ;
            case TypeEvent.smallZoneDetect:
                break ;

        }
    }

    public enum TypeEvent
    {
        simpleNote,
        fastNote,
        slowNote,
        simpleZoneDetect,
        bigZoneDetect,
        smallZoneDetect,

    }



}

// simple note fast note slow note zone detect 

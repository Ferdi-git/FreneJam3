using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TextMeshPro textMeshPro;
    private int nbr = 0 ;
    private bool isAlive = true;

    [SerializeField] TypeEvent[] listEvents;
    [SerializeField] NoteSpawner noteSpawner;



    void Start()
    {
        textMeshPro.text = nbr.ToString();
        StartCoroutine(Game());
    }


    private IEnumerator Game()
    {
        int i = 0;
        while (i < listEvents.Length)
        {
            yield return new WaitForSeconds(3);
            InvokeEvent(listEvents[i]);
        }

    }

    private void InvokeEvent(TypeEvent tEvent)
    {
        switch(tEvent)
        {
            case TypeEvent.simpleNote:
                noteSpawner.SpawnNote(2);
                break;
            case TypeEvent.fastNote:
                noteSpawner.SpawnNote(1);
                break;
            case TypeEvent.slowNote:
                noteSpawner.SpawnNote(3);
                break;
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

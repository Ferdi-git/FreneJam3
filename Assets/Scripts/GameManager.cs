using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public TextMeshPro textMeshPro;
    private int score = 0 ;
    [SerializeField] private float BPM;
    [SerializeField] NoteSpawner noteSpawner;
    [SerializeField] SOEventGame soEventGame;
    [SerializeField] GameObject winScreen;
    [SerializeField] TextMeshPro winScore;

    [SerializeField] TypeEvent[] listEvents;

    private void OnEnable()
    {
        soEventGame.PointWon += WinPoints;
        soEventGame.Win += EndGame;
    }
    private void OnDisable()
    {
        soEventGame.PointWon -= WinPoints;
        soEventGame.Win -= EndGame;

    }

    void Start()
    {
        textMeshPro.text = score.ToString();
        StartCoroutine(Game());
    }


    private IEnumerator Game()
    {
        int i = 0;
        while (i < listEvents.Length)
        {
            yield return new WaitForSeconds(BPM);
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



    public void WinPoints(int i)
    {
        score += i;
        textMeshPro.text = score.ToString();
    }


    private void EndGame()
    {
        winScreen.SetActive(true);
        StopAllCoroutines();
        winScore.text = score.ToString();
        StartCoroutine(CoRetry());
    }



    private IEnumerator CoRetry()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


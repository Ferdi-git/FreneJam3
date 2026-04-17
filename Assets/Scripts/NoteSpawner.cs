using System.Collections;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [SerializeField] private GameObject notePrefab;
    [SerializeField] private GameObject[] spawnPos;

   

    public void SpawnNote(float time)
    {
        int randint = Random.Range(0, spawnPos.Length);
        float perfectTime = Random.Range(8f, 13f);
        print(perfectTime);
        var newNote = Instantiate(notePrefab, spawnPos[randint].transform.position, Quaternion.identity);
        newNote.GetComponent<SingleNote>().timeToReachMiddle = time;
        newNote.GetComponent<SingleNote>().perfectTime = perfectTime;

    }
}

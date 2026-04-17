using System.Collections;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [SerializeField] private GameObject notePrefab;
    private void Start()
    {
        StartCoroutine(CoroutineSpawn());   
    }

    private IEnumerator CoroutineSpawn()
    {
        while (true)
        {
            SpawnNote(2);
            yield return new WaitForSeconds(5);
        }

    }

    public void SpawnNote(float time)
    {
        var newNote = Instantiate(notePrefab);
        newNote.GetComponent<SingleNote>().timeToReachMiddle = time;
    }
}

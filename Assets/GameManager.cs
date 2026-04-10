using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ZoneDetect zoneDetect;
    public GameObject innerZone;
    public GameObject outerZone;
    public TextMeshPro textMeshPro;
    public int nbr= 0 ;
    private bool isAlive = true;

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
            yield return new WaitForSeconds(5);
            if (zoneDetect.CheckIfOnIt())
            {
                nbr++;
                textMeshPro.text = nbr.ToString();
            }
            float scale = Random.Range(1, 13);
            innerZone.transform.localScale = new Vector3(scale, scale, scale);
            outerZone.transform.localScale = new Vector3(scale+5, scale+5, scale+5);
            zoneDetect.min = scale;
            zoneDetect.max = scale+5;


        }

    }


}

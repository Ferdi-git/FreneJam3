using TMPro;
using UnityEngine;

public class ZoneCheck : MonoBehaviour
{
    public ZoneDetect zoneDetect;
    public GameObject innerZone;
    public GameObject outerZone;


    public bool CheckZone()
    {
        return zoneDetect.CheckIfOnIt();
    }

    public void ChangeZone()
    {
        float scale = Random.Range(1, 13);
        innerZone.transform.localScale = new Vector3(scale, scale, scale);
        outerZone.transform.localScale = new Vector3(scale + 5, scale + 5, scale + 5);
        zoneDetect.min = scale;
        zoneDetect.max = scale + 5;

    }
}

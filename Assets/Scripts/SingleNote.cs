using DG.Tweening;
using UnityEngine;

public class SingleNote : MonoBehaviour
{


    private void FixedUpdate()
    {
        transform.DOMove(new Vector3(0, 0, 0), 2);
    }


}

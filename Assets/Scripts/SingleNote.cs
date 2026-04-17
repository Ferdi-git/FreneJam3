using DG.Tweening;
using UnityEngine;
public class SingleNote : MonoBehaviour
{
    [SerializeField] SOEventGame gameEventGame;
    [SerializeField] float destroyWindow = 0.2f; // time window after spike

    private float spikeTime = -999f;

    private void OnEnable()
    {
        gameEventGame.SpikeCheck += OnSpike;
    }
    private void OnDisable()
    {
        gameEventGame.SpikeCheck -= OnSpike;
    }
    private void Start()
    {
        transform.DOMove(new Vector3(0, 0, 0), 2).OnComplete(() => Destroy(gameObject));
    }
    private void Update()
    {
        if (Time.time - spikeTime < destroyWindow)
        {
            var hitColliders = Physics2D.OverlapCircleAll(transform.position, transform.localScale.x/2);
            for (var i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].CompareTag("Circle"))
                {
                    Destroy(gameObject);
                    return;
                }
            }
        }
    }
    private void OnSpike()
    {
        spikeTime = Time.time;
    }


}
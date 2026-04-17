using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
public class SingleNote : MonoBehaviour
{
    [SerializeField] SOEventGame gameEventGame;
    [SerializeField] float destroyWindow = 0.2f;
    public float timeToReachMiddle = 2;
    private float spikeTime = -999f;
    public float perfectTime = 5; 
    private bool playedPerfedTime = false;
    private AudioSource audioSource;
    [SerializeField] private AudioClip audioClipWarning;
    [SerializeField] private AudioClip audioClipPerfect;
    [SerializeField] private GameObject nbrPointsGO;
    private int pointsToWin;
    private bool isDestroyed = false ;

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
        pointsToWin = 1;
        audioSource = GetComponent<AudioSource>();
        transform.DOMove(new Vector3(0, 0, 0), timeToReachMiddle).SetEase(Ease.Linear).OnComplete(() => Destroy(gameObject));
    }
    private void Update()
    {
        float distFromMiddle = (transform.position - Vector3.zero).magnitude;
        
        if(distFromMiddle < perfectTime && !playedPerfedTime)
        {
            playedPerfedTime = true;

            StartCoroutine(PerfectNoteCo());
        }


        if (Time.time - spikeTime < destroyWindow)
        {
            var hitColliders = Physics2D.OverlapCircleAll(transform.position, transform.localScale.x/2);
            for (var i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].CompareTag("Circle"))
                {
                    if(isDestroyed) break;
                    isDestroyed = true;
                    nbrPointsGO.GetComponent<TextMeshPro>().text = $"+ {pointsToWin}" ;
                    gameEventGame.InvokePointWon(pointsToWin);

                    DestroyAnim();
                    return;
                }
            }
        }
    }
    private void OnSpike()
    {
        spikeTime = Time.time;
    }

    private IEnumerator PerfectNoteCo()
    {
        float randPitch = Random.Range(1f, 1.2f);
        audioSource.clip = audioClipWarning;
        pointsToWin = 1;

        audioSource.Play();

        yield return new WaitForSeconds(0.3f);
        audioSource.Play();
        
        yield return new WaitForSeconds(0.05f);
        pointsToWin = 3;

        yield return new WaitForSeconds(0.25f);
        audioSource.clip = audioClipPerfect;
        audioSource.Play();

        yield return new WaitForSeconds(0.6f);
        pointsToWin = 1;
    }

    private void DestroyAnim()
    {
        transform.DOKill();
        nbrPointsGO.SetActive(true);
        nbrPointsGO.transform.DOMoveY(nbrPointsGO.transform.position.y + 2, 2).OnComplete(()=>Destroy(gameObject));
    }
}
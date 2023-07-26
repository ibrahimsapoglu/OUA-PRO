using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SeparationOfBall : MonoBehaviour
{
    #region SINGLETON PATTERN
    private static SeparationOfBall _instance;
    public static SeparationOfBall Instance { get { return _instance; } }
    private void Awake()
    {

        if (_instance != null && _instance != this)
        {
            //Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    #endregion
    public GameObject mergeParent;
    [Range(0f, 1f)] [SerializeField] public float distanceFactor;
    [Range(0f, 1f)] [SerializeField] public float radius;
    public List<Transform> balls;
    Rigidbody rb;
    public GameObject ball;
    public GameObject[] denemeball;
    public Material[] mats;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        MakeBall(15);

    }


    void Update()
    {

    }

    public void StartMoveBalls()
    {
        StartCoroutine(MoveBalls());
    }


    public void MakeBall(int number)
    {
        for (int i = 0; i < number; i++)
        {

            GameObject ballChar = Instantiate(denemeball[Random.Range(0, denemeball.Length)], PlayerController.Instance.ballPrefabs.transform.position, PlayerController.Instance.ballPrefabs.transform.rotation);

            balls.Add(ballChar.transform);
            MergeAreaController.instance.collectedBalls.Add(ballChar);
            ballChar.transform.SetParent(mergeParent.transform);
            ballChar.SetActive(false);
            //int matIndex = Random.Range(0, mats.Length);
            //ballChar.GetComponent<MeshRenderer>().material = mats[matIndex];
        }
    }
    public void FormatBalls()
    {
        if (balls.Count >= 0)
        {

            for (int i = 0; i < balls.Count; i++)
            {
                float x = distanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * radius);
                float z = distanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * radius);
                Vector3 pos = new Vector3(x, 0, z);
                Transform ball = balls[i];
                ball.DOLocalMove(pos, .1f).SetEase(Ease.OutBack);
            }
        }

    }
    IEnumerator MoveBalls()
    {
        FormatBalls();
        yield return new WaitForSeconds(.001f);
        if (balls.Count >= 0)
        {
            for (int i = 0; i < balls.Count; i++)
            {
                balls[i].gameObject.SetActive(true);
                yield return new WaitForSeconds(.01f);
                
                //balls[i].GetComponent<Rigidbody>().isKinematic = false;
                //balls[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;

            }
        }

    }


}


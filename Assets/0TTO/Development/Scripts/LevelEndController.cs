using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelEndController : MonoBehaviour
{
    #region SINGLETON PATTERN
    private static LevelEndController _instance;
    public static LevelEndController Instance { get { return _instance; } }
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
        Application.targetFrameRate = 60;

    }

    #endregion

    public GameObject mergeParent;
    [Range(0f, 1f)] [SerializeField] public float distanceFactor;
    [Range(0f, 1f)] [SerializeField] public float radius;
    public List<Transform> balls;
    Rigidbody rb;
    public GameObject ball;
    public Material[] mats;
    public GameObject[] ballClone;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        MakeBall2(40);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartMoveBalls2()
    {
        StartCoroutine(LevelEnd());
    }
    public void MakeBall2(int number)
    {
        for (int i = 0; i < number; i++)
        {
            GameObject ballChar = Instantiate(ballClone [Random.Range(0, ballClone.Length)], PlayerController.Instance.ballPrefabs.transform.position, PlayerController.Instance.ballPrefabs.transform.rotation);
            balls.Add(ballChar.transform);
            ballChar.transform.SetParent(mergeParent.transform);
            ballChar.SetActive(false);
            //int matIndex = Random.Range(0, mats.Length);
            //ballChar.GetComponent<MeshRenderer>().material = mats[matIndex];
        }
    }
    public void FormatBalls()
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
    IEnumerator LevelEnd()
    {
        FormatBalls();
        yield return new WaitForSeconds(.001f);
        for (int i = 0; i < balls.Count; i++)
        {
            balls[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(.01f);
            balls[i].GetComponent<Rigidbody>().isKinematic = false;
            balls[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;

        }

    }
}

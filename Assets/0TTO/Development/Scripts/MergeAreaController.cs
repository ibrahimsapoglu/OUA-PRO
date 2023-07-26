using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MergeAreaController : MonoBehaviour
{
    #region SINGLETON PATTERN
    private static MergeAreaController _instance;
    public static MergeAreaController Instance { get { return _instance; } }
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
    public static MergeAreaController instance;
    public List<GameObject> collectedBalls = new List<GameObject>();
    GameObject mergeBall;
    GameObject otherSide;
    float mergeBallGrowthRate = 0.1f;
    float mainBallSize = 1f;
    int mainBallLevel;
    public GameObject ballPrefab;

    void Start()
    {
        instance = this;
        otherSide = GameObject.Find("otherside");
        mainBallLevel = 0;
        //StartMerge();
    }

    void Update()
    {

    }

    public void StartMerge()
    {
        StartCoroutine(MergeSettings());
    }
    IEnumerator MergeSettings()
    {
        yield return new WaitForSeconds(.1f);
        FindCenterPoint();
        if (collectedBalls.Count <= 0) yield break;

        /**/
        yield return new WaitForSeconds(.2f);

        foreach (GameObject gameObject in collectedBalls)
        {
            gameObject.transform.localScale = Vector3.one * .5f;
            gameObject.SetActive(false);
            Destroy(gameObject, .5f);
        }

        mergeBall = PlayerController.Instance.ballPrefabs;
        GameManager.Instance.balls.Add(mergeBall);
        mergeBall.transform.DOLocalMove(PlayerController.Instance.ballPrefabs.transform.localPosition, .1f);
        mergeBall.transform.DOScale(Vector3.one * .5f, .01f).OnComplete(() =>
          {
              mergeBall.transform.DOScale(mainBallSize, .2f);
          });
        yield return new WaitForSeconds(0.1f);
        PlayerController.Instance.ballPrefabs.SetActive(true);

    }
    float centerPointX;
    float centerPointZ;
    public void FindCenterPoint()
    {
        float x = 0;
        float z = 0;
        for (int i = 0; i < collectedBalls.Count; i++)
        {
            x += collectedBalls[i].transform.localPosition.x;
            z += collectedBalls[i].transform.localPosition.z;
        }
        centerPointX = x / collectedBalls.Count;
        centerPointZ = z / collectedBalls.Count;
        for (int i = 0; i < collectedBalls.Count; i++)
        {
            /**/
            collectedBalls[i].transform.DOLocalMove(new Vector3(centerPointX, collectedBalls[i].transform.localPosition.y, centerPointZ), .2f).SetEase(Ease.Flash);
        }
    }
}

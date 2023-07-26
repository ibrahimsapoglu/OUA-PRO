using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MoveX : MonoBehaviour
{
    Tween left;
    Tween right;
    public GameObject player;
    //void Start()
    //{
    //    //StartCoroutine(MoveLeft());
    //    float r = Random.value;
    //    if (r >= .5f)
    //    {
    //        MoveRightTween();
    //    }
    //    else
    //    {
    //        MoveLeftTween();
    //    }
    //    transform.DOMoveZ(100f, 50f);
    //}
    private void Update()
    {
        transform.DOScale(2.5f, .1f);
        if (!GameManager.Instance.isTriger)
        {
            transform.DOScale(1f, .1f);
        }
    }
    //private void OnEnable()
    //{
    //    print("enable");
    //    MoveLeft();
    //}
    //private void OnDisable()
    //{
    //    left.Kill();
    //    right.Kill();
    //}
    //IEnumerator MoveLeft()
    //{
    //    bool left = false;
    //    print("Left");
    //    while (!left)
    //    {
    //        Vector3 pos = transform.localPosition ;
    //        pos.x -= Time.deltaTime * 50f;
    //        if (pos.x <= -5f)
    //        {
    //            left = true;
    //            pos.x = -5f;
    //        }
    //        transform.position = pos;
    //        yield return new WaitForSeconds(.1f);
    //    }
    //    StartCoroutine(MoveRight());
    //}
    //IEnumerator MoveRight()
    //{
    //    bool right = false; ;
    //    while (!right)
    //    {
    //        Vector3 pos = transform.localPosition ;
    //        pos.x += Time.deltaTime * 50f;
    //        if (pos.x >= 5f)
    //        {
    //            right = true;
    //            pos.x = 5f;

    //        }
    //        transform.position = pos;
    //        yield return new WaitForSeconds(.1f);
    //    }
    //    StartCoroutine(MoveLeft());
    //}
    //void MoveLeftTween()
    //{
    //    left = transform.DOMoveX(-3f, Random.Range(3f, 4f)).OnComplete(() =>
    //    {
    //        MoveRightTween();
    //    }).SetEase(Ease.InQuad);
    //}
    //void MoveRightTween()
    //{
    //    right = transform.DOMoveX(3f, Random.Range(3f,4f)).OnComplete(() =>
    //    {
    //        MoveLeftTween();
    //    }).SetEase(Ease.InQuad);
    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Platform"))
    //    {
    //        player.GetComponent<MergeAreaController>().enabled = true;
    //    }
    //}
}

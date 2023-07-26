using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    #region SINGLETON PATTERN
    private static CanvasController _instance;
    public static CanvasController Instance { get { return _instance; } }
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
    [SerializeField] GameObject WinScreen;
    [SerializeField] GameObject LoseScreen;
    [SerializeField] GameObject InGameScreen;
    void Start()
    {
        
    }

    public void ShowWinScreenWithInvoke()
    {
        Invoke("ShowWinScreen", 0.5f);
    }
    public void ShowLoseScreenWithInvoke()

    {
        Invoke("ShowLoseScreen", 0.5f);
    }
    public void ShowWinScreen()
    {
        //ElephantSDK.Elephant.LevelCompleted(PlayerPrefs.GetInt("LEVEL"));
        ////NextButton.transform.DOScale(Vector3.zero, 0f);
        //CurrentGoldTextInWinScreen.text = GameManager.Instance.totalMoney.ToString();

        //CurrentGoldTextInWinScreen.transform.DOScale(1, .8f).OnComplete(() =>
        //{
        //    CurrentGoldTextInWinScreen.text = GameManager.Instance.totalMoney.ToString();
        //    CurrentGoldTextInWinScreen.transform.DOScale(1, .8f).OnComplete(() =>
        //    {
        //        PlayerPrefs.SetInt("TotalMoney", PlayerPrefs.GetInt("TotalMoney"));/*+LevelEndColliderController .Instance.currentX )*/
        //        TotalGoldTextInWinScreen.text = PlayerPrefs.GetInt("TotalMoney").ToString();
        //        NextButton.transform.DOScale(new Vector3(1.4f, 1.4f, 1.4f), .3f);
        //    });

        //});
        //InGameScreen.SetActive(false);
        WinScreen.SetActive(true);
        InGameScreen.SetActive(false);
    }
    void ShowLoseScreen()
    {
        //InGameScreen.SetActive(false);
        LoseScreen.SetActive(true);
        InGameScreen.SetActive(false);
    }
}

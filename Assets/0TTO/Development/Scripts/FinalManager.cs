using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;


public class FinalManager : MonoBehaviour
{

    #region SINGLETON PATTERN
    private static FinalManager _instance;
    public static FinalManager Instance { get { return _instance; } }
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
        //Application.targetFrameRate = 60;

    }

    #endregion
    //public GameObject winScreen;
    //public Transform camPos;
    void Start()
    {
        GameManager.Instance.LevelTxt.text = " LEVEL " + PlayerPrefs.GetInt("TotalLevel");
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
    }

    public void NextLevel()
    {
        int Level = PlayerPrefs.GetInt("LEVEL");
        int TotalLevel = PlayerPrefs.GetInt("TotalLevel");
        PlayerPrefs.SetInt("TotalLevel", TotalLevel + 1);
        Level++;

        if (SceneManager.sceneCountInBuildSettings - 1 < Level)
        {
            PlayerPrefs.SetInt("LEVEL", 1);
            SceneManager.LoadScene(1);
        }
        else
        {
            PlayerPrefs.SetInt("LEVEL", Level);
            SceneManager.LoadScene(Level);

        }





    }
}

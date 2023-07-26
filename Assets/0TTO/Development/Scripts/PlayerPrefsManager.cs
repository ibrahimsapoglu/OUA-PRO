using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{
    private void Awake()
    {

    }

    void Start()
    {
        if (PlayerPrefs.GetInt("LEVEL") == 0)
        {
            PlayerPrefs.SetInt("LEVEL", 1);
            PlayerPrefs.SetInt("TotalLevel", 1);
            SceneManager.LoadScene(PlayerPrefs.GetInt("LEVEL"));
        }
        else
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("LEVEL"));

        }

    }

    void Update()
    {

    }

}

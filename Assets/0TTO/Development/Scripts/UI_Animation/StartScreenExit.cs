using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StartScreenExit : MonoBehaviour
{
    #region SINGLETON PATTERN
    private static StartScreenExit _instance;
    public static StartScreenExit Instance { get { return _instance; } }
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


    [HideInInspector] public bool tapDown;
    [SerializeField] Image tapToStart;
    [SerializeField] Transform incremental;
    [SerializeField] Transform incrementalTarget;

    void Start()
    {
        tapDown = false;
    }
    void Update()
    {
        if (tapDown)
        {
            //tapDown = false;
            Taptic.Light();
            StartCoroutine(ExitAnimation());
        }

    }
    IEnumerator ExitAnimation()
    {
        
        UIAnimationManager.Instance.FadeTransparent(tapToStart, .2f, 0f);
        UIAnimationManager.Instance.Move(tapToStart.transform, incrementalTarget, .2f, 0f, false, Ease.InBack);

        UIAnimationManager.Instance.Scale(incremental, incremental.localScale.x, 0, .2f, Ease.InBack, .3f, false, false);
        UIAnimationManager.Instance.Move(incremental, incrementalTarget, .3f, 0.2f, false, Ease.InBack);

        yield return new WaitForSeconds(.4f);
        UIAnimationManager.Instance.LevelStartMethod?.Invoke();
        gameObject.SetActive(false);
        
    }
}

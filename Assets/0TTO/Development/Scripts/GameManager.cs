using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public enum ColliderType
{
    Soft,
    Middle,
    Hard,
    Collider,

}
public enum Collectable
{
    CubePink,
    CubeYellow,
    CubeBlue,
    CubeGreen,
}
public class GameManager : MonoBehaviour
{
   
    #region SINGLETON PATTERN
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
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

    [System.Serializable]
    public class CharInfo
    {
        public Collectable col;
        public Material charMaterial;
    }
    public CharInfo[] charInfo;
    public List<GameObject> balls = new List<GameObject>();
    public bool isground;
    public bool flag;
    public bool deneme;
    public GameObject ball;
    public bool isTriger;
    public Transform camPos;
    public Transform camPosFly;
    public Transform camPosGround;
    public float playerSpeed;
    public int level;
    public TextMeshProUGUI LevelTxt;
    public bool isFly;
    //public bool isMerge;
    public float totalMoney;
    public TextMeshProUGUI totalText;
    public TextMeshProUGUI moneyText;
    public GameObject cameraParticle;
    public GameObject gateTextParent;
    public bool speedCol;
    public bool groundcol;
    public bool denemecol2;
    public bool inputcontrol;
    void Start()
    {
        Application.targetFrameRate = 60;
        DOTween.SetTweensCapacity(1250, 50);
        totalMoney += PlayerPrefs.GetInt("TotalMoney");
        isground = true;
        flag  = true ;

    }

    
    void Update()
    {
        
    }
    public Material GetCharMaterial(Collectable myCol)
    {
        for (int i = 0; i < charInfo.Length; i++)
        {
            if (charInfo[i].col == myCol)
            {
                return charInfo[i].charMaterial;
            }
        }
        return null;
    }
}

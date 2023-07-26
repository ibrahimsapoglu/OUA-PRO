using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallControl : MonoBehaviour
{
    #region SINGLETON PATTERN
    private static BallControl _instance;
    public static BallControl Instance { get { return _instance; } }
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
    public Collectable trueColor;
    public bool myState;
    public Transform materialDresserParent;
    public GameObject particle;
    public GameObject mergeParticle;
    public GameObject finalParticle;
    public GameObject gateParticle;
    public GameObject moneyParticle;
    Rigidbody rb;
    public GameObject deneme;
    private Vector3 scaleChange;
    TrailRenderer trail;
    public bool cameraPos;
    public bool levelEnd;
    Animator ballAnim;
    public List<GameObject> levelEndPieces;
    void Start()
    {
        ballAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        CubeMaterial(trueColor);
    }
    public void Animations()
    {
        ballAnim.GetComponent<Animator>().enabled = true;
    }
    private void Update()
    {
        GameManager.Instance.totalText.text = GameManager.Instance.totalMoney.ToString();
        GameManager.Instance.moneyText.text = GameManager.Instance.totalMoney.ToString();
        scaleChange = new Vector3(1f, 1f, 1f);
        if (GameManager.Instance.isground && GameManager.Instance.flag && !GameManager.Instance.speedCol)
        {
            if (GameManager.Instance.playerSpeed <= 400)
            {
                GameManager.Instance.playerSpeed += .7f;
                ballAnim.speed = 3f;
            }
        }
        if (GameManager.Instance.speedCol)
        {
            ballAnim.speed = 1f;
           
        }
    }
    public void CubeMaterial(Collectable myCol)
    {
        for (int i = 0; i < materialDresserParent.childCount; i++)
        {
            materialDresserParent.GetChild(i).GetComponent<MeshRenderer>().sharedMaterial = GameManager.Instance.GetCharMaterial(myCol);
        }
    }
    public void GateChecker(Collectable other)
    {
        myState = other == trueColor;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpeedCollider"))
        {

            if (!GameManager.Instance.isground)
            {
                if (!GameManager.Instance.groundcol)
                {
                    
                    GameManager.Instance.playerSpeed = 120;
                    deneme.transform.DORotate(new Vector3(-15, 0, 0), .5f);
                    GameManager.Instance.isFly = false;
                    gateParticle = ObjectPooler.Instance.SpawnFromPool("GateParticle", new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), transform.rotation);
                    //particle = ObjectPooler.Instance.SpawnFromPool("Particle", new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), transform.rotation);
                    PlayerController.Instance.isGrounded = true;
                    GameManager.Instance.isground = true;
                    //other.GetComponent<BoxCollider>().isTrigger = false;
                    //if (PlayerController.Instance.isActive)
                    //{
                    if (GameManager.Instance.ball.transform.localScale == new Vector3(7, 7, 7))
                    {
                        SeparationOfBall.Instance.MakeBall(5);

                    }
                    if (GameManager.Instance.ball.transform.localScale == new Vector3(8, 8, 8))
                    {
                        SeparationOfBall.Instance.MakeBall(10);
                    }
                    if (GameManager.Instance.ball.transform.localScale == new Vector3(9, 9, 9))
                    {
                        SeparationOfBall.Instance.MakeBall(15);
                    }
                    if (GameManager.Instance.ball.transform.localScale == new Vector3(10, 10, 10))
                    {
                        SeparationOfBall.Instance.MakeBall(20);
                    }
                    if (GameManager.Instance.ball.transform.localScale == new Vector3(11, 11, 11))
                    {
                        SeparationOfBall.Instance.MakeBall(25);
                    }
                    if (GameManager.Instance.isground && GameManager.Instance.flag)
                    {
                        SeparationOfBall.Instance.StartMoveBalls();
                        GameManager.Instance.isground = false;
                        GameManager.Instance.deneme = false;

                    }

                }
            }
        }
        if (other.GetComponent<ColliderController>() != null)
        {
            if (other.GetComponent<ColliderController>().colliderType == ColliderType.Soft)
            {
                if (!GameManager.Instance.isFly && GameManager.Instance.isground)
                {
                    if (GameManager.Instance.playerSpeed == 120)
                    {
                        //PlayerController.Instance.speed = PlayerController.Instance.speed / 2;
                        PlayerController.Instance.speed = 1f;
                        GameManager.Instance.playerSpeed = 120f;
                        //GameManager.Instance.isground = true;
                    }
                    else
                    {
                        PlayerController.Instance.speed = 2f;
                    }
                    if (GameManager.Instance.inputcontrol)
                    {
                        PlayerController.Instance.speed = 4f;
                    }
                    GameManager.Instance.isFly = false;
                    //PlayerController.Instance.isActive = false;
                    GameManager.Instance.isground = false;
                    GameManager.Instance.flag = true;

                    PlayerController.Instance.ChangeSpeed();
                }
            }
            else if (other.GetComponent<ColliderController>().colliderType == ColliderType.Middle)
            {
                if (!GameManager.Instance.isFly && GameManager.Instance.isground)
                {
                    if (GameManager.Instance.playerSpeed == 120 /*&& GameManager.Instance.speedCol*/)
                    {
                        Debug.Log(PlayerController.Instance.speed);
                        //PlayerController.Instance.speed = PlayerController.Instance.speed / 2;
                        PlayerController.Instance.speed = 1f;
                        GameManager.Instance.playerSpeed = 120f;
                        //GameManager.Instance.isground = true;
                    }
                    else
                    {
                        PlayerController.Instance.speed = 3f;
                    }
                    if (GameManager.Instance.inputcontrol)
                    {
                        PlayerController.Instance.speed = 4f;
                    }
                    GameManager.Instance.isFly = false;
                    //PlayerController.Instance.isActive = false;
                    GameManager.Instance.isground = false;
                    GameManager.Instance.flag = true;

                    PlayerController.Instance.ChangeSpeed();
                }
            }
            else if (other.GetComponent<ColliderController>().colliderType == ColliderType.Hard)
            {

                if (!GameManager.Instance.isFly && GameManager.Instance.isground)
                {
                    if (GameManager.Instance.playerSpeed == 120)
                    {
                        PlayerController.Instance.speed = 1f;
                        GameManager.Instance.playerSpeed = 120f;
                        //PlayerController.Instance.speed = PlayerController.Instance.speed / 2;
                        //GameManager.Instance.isground = true;
                    }
                    else
                    {
                        PlayerController.Instance.speed = 5f;
                    }
                    if (GameManager.Instance.inputcontrol)
                    {
                        PlayerController.Instance.speed = 4f;
                    }
                    GameManager.Instance.isFly = false;
                    //PlayerController.Instance.isActive = false;
                    GameManager.Instance.isground = false;
                    GameManager.Instance.flag = true;

                    PlayerController.Instance.ChangeSpeed();

                }
            }
            else if (other.GetComponent<ColliderController>().colliderType == ColliderType.Collider)
            {
                //GameManager.Instance.playerSpeed -= 10;
            }

        }
        if (other.GetComponent<GateControl>() != null)
        {
            if (other.GetComponent<GateControl>().collectable == Collectable.CubePink)
            {
                transform.GetComponent<BallControl>().GateChecker(other.transform.GetComponent<GateControl>().collectable);
                if (!transform.GetComponent<BallControl>().myState)
                {
                    GameManager.Instance.gateTextParent.transform.GetChild(1).gameObject.SetActive(true);
                    GameManager.Instance.gateTextParent.transform.GetChild(0).gameObject.SetActive(false);
                    StartCoroutine(GateText(1));
                }
                else
                {
                    if (!GameManager.Instance.isTriger)
                    {
                        Taptic.Light();
                        GameManager.Instance.gateTextParent.transform.GetChild(0).gameObject.SetActive(true);
                        GameManager.Instance.gateTextParent.transform.GetChild(1).gameObject.SetActive(false);
                        GameManager.Instance.ball.transform.localScale += scaleChange;
                        GameManager.Instance.isTriger = true;
                        StartCoroutine(BallScaleChange());
                        Camera.main.transform.DOShakeRotation(.2f, 1, 1);
                        for (int i = 14; i >= 0; i--)
                        {
                            other.transform.GetChild(i).gameObject.SetActive(true);
                            Rigidbody rb = other.transform.GetChild(i).gameObject.AddComponent<Rigidbody>();
                            other.transform.GetChild(i).transform.parent = null;
                            rb.velocity += new Vector3(Random.Range(-200, 200), Random.Range(-200, 200), Random.Range(-200, 200));
                        }
                        other.gameObject.SetActive(false);
                        gateParticle = ObjectPooler.Instance.SpawnFromPool("GateParticle", new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), transform.rotation);
                        StartCoroutine(GateText(0));
                    }

                }

            }
            else if (other.GetComponent<GateControl>().collectable == Collectable.CubeYellow)
            {
                transform.GetComponent<BallControl>().GateChecker(other.transform.GetComponent<GateControl>().collectable);
                if (!transform.GetComponent<BallControl>().myState)
                {
                    GameManager.Instance.gateTextParent.transform.GetChild(1).gameObject.SetActive(true);
                    GameManager.Instance.gateTextParent.transform.GetChild(0).gameObject.SetActive(false);
                    StartCoroutine(GateText(1));
                }
                else
                {
                    if (!GameManager.Instance.isTriger)
                    {
                        Taptic.Light();
                        GameManager.Instance.gateTextParent.transform.GetChild(0).gameObject.SetActive(true);
                        GameManager.Instance.gateTextParent.transform.GetChild(1).gameObject.SetActive(false);
                        GameManager.Instance.ball.transform.localScale += scaleChange;

                        GameManager.Instance.isTriger = true;
                        StartCoroutine(BallScaleChange());
                        
                        for (int i = 14; i >= 0; i--)
                        {
                            other.transform.GetChild(i).gameObject.SetActive(true);
                            Rigidbody rb = other.transform.GetChild(i).gameObject.AddComponent<Rigidbody>();
                            other.transform.GetChild(i).transform.parent = null;
                            rb.velocity += new Vector3(Random.Range(-200, 200), Random.Range(-200, 200), Random.Range(-200, 200));
                        }
                        other.gameObject.SetActive(false);
                        gateParticle = ObjectPooler.Instance.SpawnFromPool("GateParticle", new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), transform.rotation);
                        Camera.main.transform.DOShakeRotation(.2f, 1, 1).OnComplete(() => {
                            //GameManager.Instance.gateTextParent.transform.GetChild(0).gameObject.SetActive(false);
                        });
                        StartCoroutine(GateText(0));
                    }
                }
            }
            else if (other.GetComponent<GateControl>().collectable == Collectable.CubeBlue)
            {
                transform.GetComponent<BallControl>().GateChecker(other.transform.GetComponent<GateControl>().collectable);
                if (!transform.GetComponent<BallControl>().myState)
                {
                    GameManager.Instance.gateTextParent.transform.GetChild(1).gameObject.SetActive(true);
                    GameManager.Instance.gateTextParent.transform.GetChild(0).gameObject.SetActive(false);
                    StartCoroutine(GateText(1));
                }
                else
                {
                    if (!GameManager.Instance.isTriger)
                    {
                        Taptic.Light();
                        GameManager.Instance.gateTextParent.transform.GetChild(0).gameObject.SetActive(true);
                        GameManager.Instance.gateTextParent.transform.GetChild(1).gameObject.SetActive(false);
                        GameManager.Instance.ball.transform.localScale += scaleChange;
                        GameManager.Instance.isTriger = true;
                        StartCoroutine(BallScaleChange());
                        Camera.main.transform.DOShakeRotation(.2f, 1, 1);
                        for (int i = 14; i >= 0; i--)
                        {
                            other.transform.GetChild(i).gameObject.SetActive(true);
                            Rigidbody rb = other.transform.GetChild(i).gameObject.AddComponent<Rigidbody>();
                            other.transform.GetChild(i).transform.parent = null;
                            rb.velocity += new Vector3(Random.Range(-200, 200), Random.Range(-200, 200), Random.Range(-200, 200));
                        }
                        other.gameObject.SetActive(false);
                        gateParticle = ObjectPooler.Instance.SpawnFromPool("GateParticle", new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), transform.rotation);
                        StartCoroutine(GateText(0));
                    }
                }
            }
            else if (other.GetComponent<GateControl>().collectable == Collectable.CubeGreen)
            {
                transform.GetComponent<BallControl>().GateChecker(other.transform.GetComponent<GateControl>().collectable);
                if (!transform.GetComponent<BallControl>().myState)
                {
                    GameManager.Instance.gateTextParent.transform.GetChild(1).gameObject.SetActive(true);
                    GameManager.Instance.gateTextParent.transform.GetChild(0).gameObject.SetActive(false);
                    StartCoroutine(GateText(1));
                }
                else
                {
                    if (!GameManager.Instance.isTriger)
                    {
                        Taptic.Light();
                        GameManager.Instance.gateTextParent.transform.GetChild(0).gameObject.SetActive(true);
                        GameManager.Instance.gateTextParent.transform.GetChild(1).gameObject.SetActive(false);
                        GameManager.Instance.ball.transform.localScale += scaleChange;
                        GameManager.Instance.isTriger = true;
                        StartCoroutine(BallScaleChange());
                        Camera.main.transform.DOShakeRotation(.2f, 1, 1);
                        for (int i = 14; i >= 0; i--)
                        {
                            other.transform.GetChild(i).gameObject.SetActive(true);
                            Rigidbody rb = other.transform.GetChild(i).gameObject.AddComponent<Rigidbody>();
                            other.transform.GetChild(i).transform.parent = null;
                            rb.velocity += new Vector3(Random.Range(-200, 200), Random.Range(-200, 200), Random.Range(-200, 200));
                        }
                        other.gameObject.SetActive(false);
                        gateParticle = ObjectPooler.Instance.SpawnFromPool("GateParticle", new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), transform.rotation);
                        StartCoroutine(GateText(0));
                    }
                }
            }
        }
        if (other.CompareTag("Path"))
        {
            if (!cameraPos)
            {
                Camera.main.transform.DORotate(GameManager.Instance.camPosFly.transform.eulerAngles, 5f);
                Camera.main.transform.DOLocalMove(GameManager.Instance.camPosFly.transform.localPosition, 5f);
                cameraPos = true;
            }
        }

        if (other.CompareTag("Ground"))
        {
            Taptic.Light();
            if (cameraPos)
            {
                Camera.main.transform.DORotate(GameManager.Instance.camPosGround.transform.eulerAngles, 5f);
                Camera.main.transform.DOLocalMove(GameManager.Instance.camPosGround.transform.localPosition, 5f);
                cameraPos = false;
            }

            if (!GameManager.Instance.isground)
            {

                GameManager.Instance.speedCol = false;
                GameManager.Instance.groundcol = true;
                GameManager.Instance.isFly = false;
                gateParticle = ObjectPooler.Instance.SpawnFromPool("GateParticle", new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), transform.rotation);
                //particle = ObjectPooler.Instance.SpawnFromPool("Particle", new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), transform.rotation);
                PlayerController.Instance.isGrounded = true;
                GameManager.Instance.isground = true;
                //if (PlayerController.Instance.isActive)
                //{
                if (GameManager.Instance.ball.transform.localScale == new Vector3(7, 7, 7))
                {
                    SeparationOfBall.Instance.MakeBall(5);

                }
                if (GameManager.Instance.ball.transform.localScale == new Vector3(8, 8, 8))
                {
                    SeparationOfBall.Instance.MakeBall(10);
                }
                if (GameManager.Instance.ball.transform.localScale == new Vector3(9, 9, 9))
                {
                    SeparationOfBall.Instance.MakeBall(15);
                }
                if (GameManager.Instance.ball.transform.localScale == new Vector3(10, 10, 10))
                {
                    SeparationOfBall.Instance.MakeBall(20);
                }
                if (GameManager.Instance.ball.transform.localScale == new Vector3(11, 11, 11))
                {
                    SeparationOfBall.Instance.MakeBall(25);
                }
                if (GameManager.Instance.isground && GameManager.Instance.flag)
                {
                    SeparationOfBall.Instance.StartMoveBalls();
                    GameManager.Instance.isground = false;
                    GameManager.Instance.deneme = false;
                }

            }



        }
        else if (other.CompareTag("LevelEndCol"))
        {

            other.transform.GetComponent<MeshRenderer>().enabled = false;
            other.transform.GetChild(0).gameObject.SetActive(true);
            for (int i = 0; i < levelEndPieces.Count; i++)
            {
                levelEndPieces[i].transform.parent = null;
                levelEndPieces[i].AddComponent<Rigidbody>();
                levelEndPieces[i].GetComponent<Rigidbody>().useGravity = true;
                levelEndPieces[i].GetComponent<Rigidbody>().isKinematic = false;
                levelEndPieces[i].GetComponent<Rigidbody>().velocity += new Vector3(Random.Range(-400, 400), Random.Range(-400, 400), Random.Range(-400, 400));
                Destroy(levelEndPieces[i].gameObject, 2f);

            }
            PlayerController.Instance.speed = 5f;
            PlayerController.Instance.ChangeSpeed();
            GameManager.Instance.cameraParticle.SetActive(true);
        }
        else if (other.CompareTag("FinalCol"))
        {
            Taptic.Light();
            deneme.GetComponent<CharacterController>().enabled = false;
            GameManager.Instance.totalMoney += other.GetComponent<FinalCollider>().value;
            PlayerPrefs.SetInt("TotalMoney", Mathf.RoundToInt(GameManager.Instance.totalMoney));
            Debug.Log(FinalCollider.Instance.value);
            
            finalParticle = ObjectPooler.Instance.SpawnFromPool("FinalParticle", new Vector3(other.transform.position.x, other.transform.position.y + 1f, other.transform.position.z), other.transform.rotation);
            moneyParticle = ObjectPooler.Instance.SpawnFromPool("MoneyParticle", new Vector3(other.transform.position.x, other.transform.position.y + 1f, other.transform.position.z), other.transform.rotation);
            
            //other.GetComponent<BoxCollider>().isTrigger = false;
            
            rb.useGravity = false;
            rb.isKinematic = true;
            transform.GetComponent<SphereCollider>().isTrigger = false;
            LevelEndController.Instance.StartMoveBalls2();
            Camera.main.transform.DOLocalMove(GameManager.Instance.camPos.transform.localPosition, .5f);
            Camera.main.transform.DORotate(GameManager.Instance.camPos.transform.eulerAngles, .5f).OnComplete(() =>
            {

                //particle.SetActive(false);
            });
            
            CanvasController.Instance.ShowWinScreenWithInvoke();
            //winPanel

        }
        else if (other.CompareTag("Jump"))
        {
            print("fd");
            //finalParticle = ObjectPooler.Instance.SpawnFromPool("FinalParticle", new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), transform.rotation);
            //moneyParticle = ObjectPooler.Instance.SpawnFromPool("MoneyParticle", new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), transform.rotation);
            Taptic.Light();
            rb.AddForce(transform.up * 500);
            rb.useGravity = true;
            rb.isKinematic = false;
            //LevelEndController.Instance.StartMoveBalls2();
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("SpeedCollider"))
        {

            if (!GameManager.Instance.groundcol)
            {
                print("stay");
                GameManager.Instance.speedCol = true;
                other.GetComponent<BoxCollider>().isTrigger = false;
            }
            else
            {
                other.GetComponent<BoxCollider>().isTrigger = true;
            }
          
        }
        if (other.GetComponent<ColliderController>() == null) return;
        if (other.GetComponent<ColliderController>().colliderType == ColliderType.Soft)
        {

            if (!GameManager.Instance.isFly && GameManager.Instance.isground)
            {
                //PlayerController.Instance.isActive = false;
                GameManager.Instance.isground = false;
                GameManager.Instance.flag = true;
                if (GameManager.Instance.playerSpeed == 120)
                {
                    //PlayerController.Instance.speed = PlayerController.Instance.speed / 2;
                    PlayerController.Instance.speed = 1f;
                    GameManager.Instance.playerSpeed = 120f;
                    //GameManager.Instance.isground = true;
                }
                else
                {
                    PlayerController.Instance.speed = 2f;
                }
                if (GameManager.Instance.inputcontrol)
                {
                    PlayerController.Instance.speed = 4f;
                }
                //PlayerController.Instance.speed = 2f;
                PlayerController.Instance.ChangeSpeed();
            }
        }

        else if (other.GetComponent<ColliderController>().colliderType == ColliderType.Middle)
        {
            if (!GameManager.Instance.isFly && GameManager.Instance.isground)
            {
                //PlayerController.Instance.isActive = false;
                GameManager.Instance.isground = false;
                GameManager.Instance.flag = true;
                if (GameManager.Instance.playerSpeed == 120)
                {
                    PlayerController.Instance.speed = 1f;
                    GameManager.Instance.playerSpeed = 120f;
                    //PlayerController.Instance.speed = PlayerController.Instance.speed / 2;
                    //GameManager.Instance.isground = true;
                }
                else
                {
                    PlayerController.Instance.speed = 3f;
                }
                if (GameManager.Instance.inputcontrol)
                {
                    PlayerController.Instance.speed = 4f;
                }
                //PlayerController.Instance.speed = 4f;
                PlayerController.Instance.ChangeSpeed();
            }
        }
        else if (other.GetComponent<ColliderController>().colliderType == ColliderType.Hard)
        {
            if (!GameManager.Instance.isFly && GameManager.Instance.isground)
            {
                //PlayerController.Instance.isActive = false;
                GameManager.Instance.isground = false;
                GameManager.Instance.flag = true;
                if (GameManager.Instance.playerSpeed == 120)
                {
                    PlayerController.Instance.speed = 1f;
                    GameManager.Instance.playerSpeed = 120f;
                    //PlayerController.Instance.speed = PlayerController.Instance.speed / 2;
                    //GameManager.Instance.isground = true;
                }
                else
                {
                    PlayerController.Instance.speed = 5f;
                }
                if (GameManager.Instance.inputcontrol)
                {
                    PlayerController.Instance.speed = 4f;
                }
                //PlayerController.Instance.speed = 5f;
                PlayerController.Instance.ChangeSpeed();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SpeedCollider"))
        {

            if (!GameManager.Instance.groundcol)
            {
                GameManager.Instance.speedCol = false;
                GameManager.Instance.groundcol = true;
                GameManager.Instance.isground = true;
                deneme.transform.DORotate(new Vector3(0, 0, 0), .5f);
            }
           
        }
        if (other.GetComponent<ColliderController>() != null)
        {
            if (other.GetComponent<ColliderController>().colliderType == ColliderType.Soft)
            {
                if (GameManager.Instance.playerSpeed == 120)
                {
                    print(PlayerController.Instance.speed);
                    PlayerController.Instance.speed = 1.5f;
                    GameManager.Instance.playerSpeed = 120f;
                    //PlayerController.Instance.speed = PlayerController.Instance.speed / 2;
                }
                //PlayerController.Instance.isActive = true;
                if (!GameManager.Instance.isFly)
                {
                    if (!GameManager.Instance.isground && GameManager.Instance.flag)
                    {

                        StartCoroutine(MergeMovement(15));
                        //GameManager.Instance.groundcol = false ;

                    }
                }
                if (GameManager.Instance.inputcontrol)
                {
                    PlayerController.Instance.speed = 4f;
                }
            }
            else if (other.GetComponent<ColliderController>().colliderType == ColliderType.Middle)
            {
                if (GameManager.Instance.playerSpeed == 120)
                {
                    print(PlayerController.Instance.speed);
                    PlayerController.Instance.speed = 1.5f;
                    GameManager.Instance.playerSpeed = 120f;
                    //PlayerController.Instance.speed = PlayerController.Instance.speed / 2;
                }
                //PlayerController.Instance.isActive = true;
                if (!GameManager.Instance.isFly)
                {
                    if (!GameManager.Instance.isground && GameManager.Instance.flag)
                    {
                        StartCoroutine(MergeMovement(15));
                    }
                }
                if (GameManager.Instance.inputcontrol)
                {
                    PlayerController.Instance.speed = 4f;
                }
            }
            else if (other.GetComponent<ColliderController>().colliderType == ColliderType.Hard)
            {
                if (GameManager.Instance.playerSpeed == 120)
                {
                    print(PlayerController.Instance.speed);
                    PlayerController.Instance.speed = 1.5f;
                    GameManager.Instance.playerSpeed = 120f;
                    //PlayerController.Instance.speed = PlayerController.Instance.speed / 2;
                }
                //PlayerController.Instance.isActive = true;
                if (!GameManager.Instance.isFly)
                {
                    if (!GameManager.Instance.isground && GameManager.Instance.flag)
                    {
                        StartCoroutine(MergeMovement(15));
                    }
                }
                if (GameManager.Instance.inputcontrol)
                {
                    PlayerController.Instance.speed = 4f;
                }
            }
        }
    }

    IEnumerator MergeMovement(int number)
    {
        Taptic.Medium();
        //if (!GameManager.Instance.isFly)
        //{
        ballAnim.speed = 1f;
        yield return new WaitForSeconds(.01f);
        MergeAreaController.instance.StartMerge();
        mergeParticle = ObjectPooler.Instance.SpawnFromPool("MergeParticle", new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), transform.rotation);
        yield return new WaitForSeconds(.5f);
        SeparationOfBall.Instance.balls.Clear();
        MergeAreaController.instance.collectedBalls.Clear();

        yield return new WaitForSeconds(.3f);
        SeparationOfBall.Instance.MakeBall(number);
        yield return new WaitForSeconds(.3f);
        //GameManager.Instance.isFly = false;
        GameManager.Instance.speedCol = false;
        GameManager.Instance.groundcol = false;
        //yield return new WaitForSeconds(1f);
        //GameManager.Instance.isground = true;
        //}

    }
    public void Merge()
    {
        StartCoroutine(MergeMovement(15));
    }
    IEnumerator BallScaleChange()
    {
        yield return new WaitForSeconds(.5f);
        GameManager.Instance.isTriger = false;
    }
    public void GatePieces(List<GameObject> myList)
    {
        for (int i = 0; i < myList.Count; i++)
        {
            myList[i].transform.parent = null;
            myList[i].AddComponent<Rigidbody>();
            myList[i].GetComponent<Rigidbody>().useGravity = true;
            myList[i].GetComponent<Rigidbody>().isKinematic = false;
            myList[i].GetComponent<Rigidbody>().velocity += new Vector3(Random.Range(-200, 200), Random.Range(-200, 200), Random.Range(-200, 200));
            //Destroy(myList[i].gameObject, 2f);
            //myList.Clear();

        }
    }
    IEnumerator GateText(int index)
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.gateTextParent.transform.GetChild(index).gameObject.SetActive(false);
    }
    
}






























//if (other.CompareTag("BlueHole"))
//{

//    transform.GetComponent<CubeController>().HoleChecker(other.transform.GetComponent<HoleController>().collectable);
//    if (!transform.GetComponent<CubeController>().myState)
//    {

//    }
//    else
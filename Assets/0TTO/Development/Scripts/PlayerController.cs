using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{

    #region SINGLETON PATTERN
    private static PlayerController _instance;
    public static PlayerController Instance { get { return _instance; } }
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
    [SerializeField] private Vector3 playerVelocity;

    private CharacterController characterController;
    public Transform ground;
    public float distance;
    public float gravity;
    public float speed;
    private Vector3 movement;
    public bool isGrounded;
    public List<GameObject> ballList;
    public GameObject deneme;
    public GameObject ballPrefabs;
    public GameObject player;
    public bool isFly;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float minXAngle = -60, maxXAngle = 60;
    public float diveAngleSpeed = 2, gravityForBalls = 1;
    //public bool isActive = true;
    Rigidbody rb;


    public float rotationSpeed = 5f;
    public float minRotation = 0f;
    public float maxRotation = 15f;
    float rotation = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
    }
    void ChangeSpeedAmount()
    {
        speed -= .7f;
    }

    void Update()
    {
        //if (!isActive)
        //{
        //    return;
        //}

        if (Input.GetMouseButtonDown(0) && !GameManager.Instance.isground && !GameManager.Instance.isFly)
        {
            transform.rotation = Quaternion.Euler(rotation, 0f, 0f);
            InvokeRepeating("ChangeSpeedAmount", 0, .1f);
           
        }
       
        if (Input.GetMouseButton(0))
        {
            GameManager.Instance.inputcontrol = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            GameManager.Instance.inputcontrol = false;
            GameManager.Instance.isFly = false;
            CancelInvoke("ChangeSpeedAmount");
        }
       
        if (characterController.isGrounded)
        {
            GameManager.Instance.isground = true;
            isGrounded = true;
        }
        else
        {
            GameManager.Instance.isground = false;
            isGrounded = false;
          
        }
        

    }
    private void FixedUpdate()
    {
        if (StartScreenExit.Instance.tapDown)
        {
            float verticalSpeed = characterController.velocity.y;
            
            //Debug.Log(verticalSpeed);
            movement = new Vector3(0f, speed , GameManager.Instance.playerSpeed * Time.deltaTime);
            characterController.Move(movement);
            CheckGround();
            BallControl.Instance.Animations();

        }
    }
    private void CheckGround()
    {
        var ray = new Ray(transform.position + Vector3.down * 2, Vector3.down);

        RaycastHit hitInfo;

        isFly = !Physics.Raycast(ray, out hitInfo, 6, layerMask);
    }
    public void ChangeSpeed()
    {
        CancelInvoke("SpeedController");
        InvokeRepeating("SpeedController", 0, .1f);
    }
    public void SpeedController()
    {
        speed -= .15f;
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinalCollider : MonoBehaviour
{
    #region SINGLETON PATTERN
    private static FinalCollider _instance;
    public static FinalCollider Instance { get { return _instance; } }
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

    public float value;
    private void Start()
    {
        //value = LevelEndUIController.Instance.number;
        value = Random.Range(0, 250);
    }































    //public bool isFly;
    //[SerializeField] private LayerMask layerMask;
    //[SerializeField] private float minXAngle = -60, maxXAngle = 60;
    //public float diveAngleSpeed = 2, gravityForBalls = 1;

    //void Start()
    //{

    //}


    //void Update()
    //{
    //    if ( !isFly)
    //    {
    //        Dive();
    //        print("isFly");
    //    }
    //    else if (isFly )
    //    {
    //        DecreaseAngleX(gravityForBalls);
    //    }

    //}

    //private void FixedUpdate()
    //{
    //    CheckGround();
    //}
    //private void CheckGround()
    //{
    //    var ray = new Ray(transform.position + Vector3.up * 2, Vector3.down);

    //    RaycastHit hitInfo;

    //    isFly = !Physics.Raycast(ray, out hitInfo, 4, layerMask);
    //}
    //private void Dive()
    //{
    //    DecreaseAngleX(diveAngleSpeed);
    //}

    //private void DecreaseAngleX(float constant)
    //{
    //    var angleX = transform.eulerAngles.x;
    //    var newAngles = Vector3.zero;

    //    newAngles.x = angleX + Time.deltaTime * constant;
    //    newAngles.x = ClampAngle(newAngles.x, minXAngle, maxXAngle);

    //    //transform.eulerAngles = newAngles;
    //    transform.rotation = Quaternion.Euler(newAngles);
    //    //transform.Rotate(Vector3.right * Time.deltaTime * constant);

    //}

    //private static float ClampAngle(float angle, float from, float to)
    //{
    //    if (angle < 0f) angle = 360 + angle;

    //    return angle > 180f ? Mathf.Max(angle, 360 + from) : Mathf.Min(angle, to);
    //}
}

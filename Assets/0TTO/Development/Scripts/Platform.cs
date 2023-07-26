using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //GameManager.Instance.deneme = true;
            print("dfv");
            PlayerController.Instance.isGrounded = true;
            GameManager.Instance.isground = true;
            //if (GameManager.Instance.deneme)
            //{
                if (GameManager.Instance.isground && !GameManager.Instance.flag && PlayerController.Instance.isGrounded)
                {

                    SeparationOfBall.Instance.StartMoveBalls();
                    //GameManager .Instance.isground  = false;
                    GameManager.Instance.flag = true ;
                    GameManager.Instance.deneme = false;
                }
            //}
           
            
            //else if (!PlayerController.Instance.isGrounded && GameManager.Instance.flag)
            //{
            //    BallControl.Instance.Merge();
            //}
            {

                //SeparationOfBall.Instance.StartMoveBalls();
                //PlayerController.Instance.isGrounded = true;
            }


            //GameManager.Instance.isground = false;
            //GameManager.Instance.flag = true;
            //if (!GameManager.Instance.isground && GameManager.Instance.flag)
            //{
            //    SeparationOfBall.Instance.StartMoveBalls ();
            //    GameManager.Instance.isground = true;
            //}
            //else
            //{
            //    //BallControl.Instance.Merge();

            //    //GameManager.Instance.isground = false ;
            //}
            //print("df");
        }
    }
}

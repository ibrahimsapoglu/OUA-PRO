using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    #region SINGLETON PATTERN
    private static CharacterMovement _instance;
    public static CharacterMovement Instance { get { return _instance; } }
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
    public float speed;
    void Start()
    {
        
    }

   
    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * speed , Space.World);
    }
}

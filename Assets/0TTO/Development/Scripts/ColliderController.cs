using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    public ColliderType colliderType;

    private Vector3 scaleChange;
    public  GameObject sphere;
    
    private void Awake()
    {
        scaleChange = new Vector3(1f, 1f, 1f);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}

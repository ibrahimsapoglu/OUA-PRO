using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GateControl : MonoBehaviour
{
    public Collectable collectable;
    public Material material;
    private Vector3 scaleChange;
    public GameObject ball;
     public List<GameObject> ballList;
    public bool isTriger;
    public List<GameObject> pieces;
    List<GameObject> piece = new List<GameObject>();

    private void Start()
    {
        GateDeneme();
    }
    private void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTriger = false ;
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag ("Player"))
        {
            isTriger = true;
           
        }
    }
    
    public void GateDeneme()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }
    [Range(1,10)]
    public float smootherFactor;
    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        //transform.position = target.position + offset;
        var targetPosition = target.position + offset;
        var smootherPosition = Vector3.Lerp(transform.position,targetPosition,smootherFactor*Time.fixedDeltaTime);
        transform.position = smootherPosition;
        
    }
}

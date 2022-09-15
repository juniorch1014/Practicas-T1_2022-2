using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins_Controller : MonoBehaviour
{
    // Start is called before the first frame update
   
    AudioSource audioSource;
    void Start()
    {
        Debug.Log("Iniciando Script de Coins");
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Trigger coins");
        if(other.gameObject.name == "Knight_Player"){
            Destroy(this.gameObject);
        }
       
    }
}

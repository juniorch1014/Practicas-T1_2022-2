
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AttEsc_Controller : MonoBehaviour
{   
 
    private float velocity = 10;
    private GameManagerController gameManager;
    Rigidbody2D rb;
    // Start is called before the first frame update
    float realVelocity;
    public void SetRightDirection(){
        realVelocity = velocity;
    }
    public void SetLeftDirection(){
        realVelocity = -velocity;
    }
    void Start()
    {
        gameManager = FindObjectOfType<GameManagerController>();
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject,5);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(realVelocity,0);
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag =="base" ){
            Destroy(this.gameObject);
        }
        if(other.gameObject.tag =="zombie"){
            Destroy(this.gameObject);
       
        }
    }
     void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Trigger pared");
        if(other.gameObject.tag =="pared"){
            Destroy(this.gameObject);
        }
      
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja_AtaqueController : MonoBehaviour
{
private float velocity = 10;
    private GameManager_Ninja gameManager_Ninja;
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
        gameManager_Ninja = FindObjectOfType<GameManager_Ninja>();
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
            gameManager_Ninja.GanarPuntos(10);
        }
    }
     void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Trigger pared");
        if(other.gameObject.tag =="pared"){
            Destroy(this.gameObject);
        }
      
    }
}

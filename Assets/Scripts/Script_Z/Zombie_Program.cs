using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Program : MonoBehaviour
{
    private GameManagerController gameManager;

   // private int velocity   = 5;
    private int run_velZ    = 10;
    
    Rigidbody2D rb;
    
    Animator animatorZ;
    SpriteRenderer sr;
   
    const int Anima_Walk   = 4;
    
  //  bool Ani_Salto = false;
  
    

    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log("Iniciando Script de Zombie");
        rb = GetComponent<Rigidbody2D>();
        animatorZ = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
            sr.flipX = true;
            rb.velocity = new Vector2(-run_velZ, rb.velocity.y);
            ChangeAnimation(Anima_Walk);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
 
    
        if(other.gameObject.tag == "shield"){
           Destroy(this.gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Trigger");
        if(other.gameObject.name == "Paredes (7)"){
        Destroy(this.gameObject);
        }
    }

    private void ChangeAnimation(int animation){     
        animatorZ.SetInteger("EstadoZ",animation);
    }
    private void ChangeAnimation_Bool(bool animat_bool){
        animatorZ.SetBool("Saltar",animat_bool);
    }
    
}
